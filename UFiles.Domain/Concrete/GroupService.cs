using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class GroupService : IGroupService
    {
        private IRepository<Group> groupRepo = new Repository<Group>();
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public GroupService()
        {
            groupRepo.UnitOfWork = unitOfWork;
        }

        public IQueryable<Group> GetGroupsByOwner(Entities.User owner)
        {
            return groupRepo.Where(g => g.Owner.UserId == owner.UserId);
        }

        public Entities.Group GetGroup(int id)
        {
            return groupRepo.Where(g => g.GroupId == id).Single();
        }

        public Entities.Group CreateGroup(Entities.User owner)
        {
            var group = new Group();
            group.Owner = owner;
            groupRepo.Add(group);
            unitOfWork.Commit();
            return group;
        }

        public void AddMember(Group group, User member)
        {
            group.Users.Add(member);
            groupRepo.Update(group);
            unitOfWork.Commit();
        }

        public void RemoveMember(Group group, User member)
        {
            group.Users.Remove(member);
            groupRepo.Update(group);
            unitOfWork.Commit();
        }

        public void DeleteGroup(Group group)
        {
            groupRepo.Delete(group);
            unitOfWork.Commit();
        }
    }
}
