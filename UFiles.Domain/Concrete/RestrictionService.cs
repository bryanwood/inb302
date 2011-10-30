﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using System.Data.Entity;
using UFiles.Domain.Entities;
namespace UFiles.Domain.Concrete
{
    public class RestrictionService : IRestrictionService
    {
        private IUFileContext db;
        public RestrictionService(IUFileContext context)
        {
            db = context;
        }

        public void AddUserRestriction(int fileId, int[] userIds)
        {
            var file = db.Files.Include(x=>x.Restrictions).Where(x=>x.FileId==fileId).Single();
            var userRestriction = new UserRestriction();
            userRestriction.Users = new List<User>();
            foreach(var userId in userIds){
                userRestriction.Users.Add(db.Users.Find(userId));
            }
            file.Restrictions.Add(userRestriction);
            db.SaveChanges();
        }

        public void AddGroupRestriction(int fileId, int[] groupIds)
        {
            var file = db.Files.Include(x => x.Restrictions).Where(x=>x.FileId==fileId).Single();
            var groupRestriction = new GroupRestriction();
            groupRestriction.Groups = new List<Group>();
            foreach (var groupId in groupIds)
            {
                groupRestriction.Groups.Add(db.Groups.Find(groupId));
            }
            file.Restrictions.Add(groupRestriction);
            db.SaveChanges();
        }

        public void AddTimeRangeRestriction(int fileId, TimeRange[] timeRanges)
        {
            var file = db.Files.Include(x => x.Restrictions).Where(x=>x.FileId==fileId).Single();
            var timeRestriction = new TimeRangeRestriction();
            timeRestriction.TimeRanges = new List<TimeRange>();
            foreach (var timeRange in timeRanges)
            {
                timeRestriction.TimeRanges.Add(timeRange);
            }
            file.Restrictions.Add(timeRestriction);
            db.SaveChanges();
        }
        public void AddIPRestriction(int fileId, string[] ips)
        {
            var file = db.Files.Include(x => x.Restrictions).Where(x => x.FileId==fileId).Single();
            var ipRestriction = new IPRestriction();
            ipRestriction.IPAddress = new List<IPAddress>();
            var ipz = ips.Select(x => new IPAddress
            {
                IP = x
            });
            foreach (var ip in ipz)
            {
                ipRestriction.IPAddress.Add(ip);
            }
            file.Restrictions.Add(ipRestriction);
            db.SaveChanges();
        }
    }
}
