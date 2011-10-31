using System;
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
        private IEventService eventService;
        public FileService(IUFileContext context, IEventService eventService)
        {
            this.eventService = eventService;
            db = context;
        }
        public File GetFileById(int id)
        {
            var file = db.Files.Find(id);
            eventService.AddFileAccessEvent(file, file.Owner);
            return file;
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
                if (file.OwnerId != userId)
                {
                    if (file.Restrictions.Count > 0)
                    {
                        foreach (var restriction in file.Restrictions.OfType<UserRestriction>())
                        {
                            var res = db.Restrictions.OfType<UserRestriction>().Include(x => x.Users).Where(r => r.RestrictionId == restriction.RestrictionId).Single();
                            if(res.Users.Contains(user))
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
                            var res = db.Restrictions.OfType<GroupRestriction>().Include(x => x.Groups).Where(r => r.RestrictionId == restriction.RestrictionId).Single();

                            foreach (var g in res.Groups)
                            {
                                g.Users = (from groups in db.Groups
                                           where groups.GroupId == g.GroupId
                                           select groups.Users).Single();
                                if (g.Users.Contains(user))
                                {
                                    t = true;
                                }
                            }
                            groupAccess.Add(t);
                        }
                        foreach (var time in file.Restrictions.OfType<TimeRangeRestriction>())
                        {
                            bool t = false;
                            var res = db.Restrictions.OfType<TimeRangeRestriction>().Include(x => x.TimeRanges).Where(r => r.RestrictionId == time.RestrictionId).Single();

                            var now = DateTime.Now;
                            foreach (var timeRange in res.TimeRanges)
                            {
                                if (now.CompareTo(timeRange.End.Value) < 0 && now.CompareTo(timeRange.Start) > 0)
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
            eventService.AddFileAccessEvent(file, user);
            return canAccess;
        }
       
        public void CreateFile(File file)
        {
            db.Files.Add(file);
            db.SaveChanges();
            eventService.AddFileAccessEvent(file, file.Owner);
        }
     
        public void RevokeFile(int id)
        {
            var file = db.Files.Find(id);
            file.Revoked = true;
            db.SaveChanges();
            eventService.AddFileAccessEvent(file, file.Owner);
        }
    }
}
