﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Data.Entity;

namespace UFiles.Domain.Concrete
{
    public class FileService : IFileService
    {
        private IUFileContext db;
        public FileService(IUFileContext context)
        {
            db = context;
        }
        public File GetFileById(int id)
        {
            return db.Files.Find(id);
        }

        public bool UserCanAccessFile(int id, int userId, int locationId, string iPAddress)
        {
            var file = db.Files.Include(x=>x.Restrictions).Where(x=>x.FileId==id).Single();
            var user = db.Users.Find(userId);
            var timeAccess = new List<bool>();
            var userAccess = new List<bool>();
            var groupAccess = new List<bool>();
            bool canAccess = false;
            //check if it has any restrictions to enumerate
            if (file.Revoked && userId != file.OwnerId)
            {
                canAccess = false;
            }
            else
            {
                if (file.OwnerId == userId)
                {
                    if (file.Restrictions.Count > 0)
                    {
                        foreach (var restriction in file.Restrictions.OfType<UserRestriction>())
                        {
                            if (restriction.Users.Contains(user))
                            {
                                userAccess.Add(true);
                            }
                            else
                            {
                                userAccess.Add(false);
                            }
                        }
                        foreach (var restriction in file.Restrictions.OfType<GroupRestriction>())
                        {
                            bool t = false;
                            foreach (var group in restriction.Groups)
                            {

                                if (group.Users.Contains(user))
                                {
                                    t = true;
                                }
                            }
                            groupAccess.Add(t);
                        }
                        foreach (var time in file.Restrictions.OfType<TimeRangeRestriction>())
                        {
                            bool t = false;
                            var now = DateTime.Now;
                            foreach (var timeRange in time.TimeRanges)
                            {
                                if (now < timeRange.End && now > timeRange.Start)
                                {
                                    t = true;
                                }
                            }
                            timeAccess.Add(t);
                        }
                        if (userAccess.Contains(false) || timeAccess.Contains(false) || groupAccess.Contains(false))
                        {
                            canAccess = false;
                        }
                        else
                        {
                            canAccess = true;
                        }

                    }
                    else
                    {
                        //Unrestricted file, anyone can use
                        canAccess = true;
                    }
                }
                else
                {
                    canAccess = true;
                }
            }

            return canAccess;
        }
       
        public void CreateFile(File file)
        {
            db.Files.Add(file);
            db.SaveChanges();
        }
     
        public void RevokeFile(int id)
        {
            var file = db.Files.Find(id);
            file.Revoked = true;
            db.SaveChanges();
        }
    }
}