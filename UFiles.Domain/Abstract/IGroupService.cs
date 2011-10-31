using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IGroupService
    {
        /// <summary>
        /// Gets a list of groups owned by the specified user
        /// </summary>
        /// <param name="owner">the user to get the groups for</param>
        /// <returns>list of groups</returns>
        IQueryable<Group> GetGroupsByOwner(User owner);

        /// <summary>
        /// gets a specific group by its id
        /// </summary>
        /// <param name="id">the id of the group to get</param>
        /// <returns>a group</returns>
        Group GetGroup(int id);

        Group GetGroupByName(string name);
        /// <summary>
        /// Creates a new group for a specified user
        /// </summary>
        /// <param name="owner">the user to create the group for</param>
        /// <param name="group">the group to create</param>
        void CreateGroup(User owner, Group group);

        /// <summary>
        /// saves a groups changes
        /// </summary>
        /// <param name="group">the group thats been changed</param>
        void SaveGroup(Group group);

        /// <summary>
        /// Adds the specified user to the group
        /// </summary>
        /// <param name="group">the group to add the user to</param>
        /// <param name="member">the user to add to the group</param>
        void AddMember(Group group, User member);

        /// <summary>
        /// Removes the specified user from the group
        /// </summary>
        /// <param name="group">the group to remove the user from</param>
        /// <param name="member">the user to remove from the group</param>
        void RemoveMember(Group group, User member);

        /// <summary>
        /// Deletes an entire group
        /// </summary>
        /// <param name="group">the group to delete</param>
        void DeleteGroup(Group group);
    }
}
