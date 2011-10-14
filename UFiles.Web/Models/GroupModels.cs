using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFiles.Domain.Entities;

namespace UFiles.Web.Models
{
    public class GroupListingModel
    {

        public int groupID { get; set; }
        public string groupName { get; set; }
        public List<User> includedUsers { get; set; }

        public GroupListingModel(Group g)
        {
            this.groupID = g.GroupId;
            this.groupName = g.Name;

            foreach (User u in g.Users)
            {
                this.includedUsers.Add(u);
            }
        }

    }
}