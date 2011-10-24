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
        private IUnitOfWork unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Group> GetGroupsByOwner(Entities.User owner)
        {
            return unitOfWork.GroupRepository.Where(g => g.Owner.UserId == owner.UserId);
        }

        public Entities.Group GetGroup(int id)
        {
            return unitOfWork.GroupRepository.Where(g => g.GroupId == id).Single();
        }

        public void CreateGroup(Entities.User owner, Group group)
        {
            group.Owner = owner;
            unitOfWork.GroupRepository.Add(group);
            unitOfWork.Save();
        }

        public void AddMember(Group group, User member)
        {
            group.Users.Add(member);
            unitOfWork.GroupRepository.Update(group);
            unitOfWork.Save();
        }

        public void RemoveMember(Group group, User member)
        {
            group.Users.Remove(member);
            unitOfWork.GroupRepository.Update(group);
            unitOfWork.Save();
        }

        public void SaveGroup(Group group)
        {
            unitOfWork.GroupRepository.Update(group);
            unitOfWork.Save();
        }

        public void DeleteGroup(Group group)
        {
            unitOfWork.GroupRepository.Delete(group);
            unitOfWork.Save();
        }
    }
}
