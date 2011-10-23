﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFiles.Domain.Entities;
using UFiles.Domain.Abstract;
using System.Threading;

namespace UFiles.Web.Models
{
    public class GroupListingModel
    {

        public int groupID { get; set; }
        public User owner { get; set; }
        public string groupName { get; set; }
        public List<User> includedUsers { get; set; }

        public GroupListingModel(Group g)
        {
            this.groupID = g.GroupId;
            this.groupName = g.Name;
            this.owner = g.Owner;
            this.includedUsers = new List<User>();

            foreach (User u in g.Users)
            {
                this.includedUsers.Add(u);
            }
        }

    }

    public class GroupDetailModel : BaseAuthenticatedModel
    {

        public int groupID { get; set; }
        public string groupName { get; set; }
        public string groupUsers { get; set; }

        public GroupDetailModel(int groupID, IGroupService groupService, 
            IUserService userService, string email) : base(userService, email)
        {
            Group g = groupService.GetGroup(groupID);

            if (g == null)
            {
                return;
            }

            if (g.Owner.UserId != base.getUser().ID)
            {
                return;
            }

            this.groupID = g.GroupId;
            this.groupName = g.Name;

            foreach (User u in g.Users)
            {
                this.groupUsers += u.Email + "; ";
            }

        }

    }
}