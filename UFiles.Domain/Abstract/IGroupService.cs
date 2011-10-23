using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IGroupService
    {
        IQueryable<Group> GetGroupsByOwner(User owner);
        Group GetGroup(int id);
        Group CreateGroup(User owner);
        void AddMember(Group group, User member);
        void RemoveMember(Group group, User member);
        void DeleteGroup(Group group);
    }
}
