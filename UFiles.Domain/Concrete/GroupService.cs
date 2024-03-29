﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using System.Data.Entity;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class GroupService : IGroupService
    {
        private IUFileContext db;
        

        public GroupService(IUFileContext context)
        {
            db = context;
        }

        public IQueryable<Group> GetGroupsByOwner(Entities.User owner)
        {
            return db.Groups.Include(x=>x.Users).Include(x=>x.Owner).Where(g => g.Owner.UserId == owner.UserId);
        }
        public Entities.Group GetGroupByName(string name)
        {
            return db.Groups.Include(x => x.Owner).Include(x => x.Users).Where(g => g.Name == name).Single();
        }
        public Entities.Group GetGroup(int id)
        {
            return db.Groups.Include(x=>x.Owner).Include(x=>x.Users).Where(g => g.GroupId == id).Single();
        }

        public void CreateGroup(Entities.User owner, Group group)
        {
            group.Owner = owner;
            db.Groups.Add(group);
            db.SaveChanges();
        }

        public void AddMember(Group group, User member)
        {
            group.Users.Add(member);
            db.Entry(group).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveMember(Group group, User member)
        {
            group.Users.Remove(member);
            db.Entry(group).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void SaveGroup(Group group)
        {
            db.Entry(group).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteGroup(Group group)
        {
            db.Groups.Remove(group);
            db.SaveChanges();
        }
    }
}
