using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFiles.Domain.Entities;
using UFiles.Domain.Abstract;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Concrete;

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

            if (g.Users != null)
            {
                foreach (User u in g.Users)
                {
                    this.includedUsers.Add(u);
                }
            }
        }

    }

    public class EditGroupModel : CreateGroupModel
    {
        public int GroupID { get; set; }
    }

    public class CreateGroupModel
    {

        [Required(ErrorMessage = "<p>You must enter a group name.</p>")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "<p>You must enter at least one email address.</p>")]
        public string UserEmailAddresses { get; set; }
        private List<String> _emailAddressList;

        public List<String> EmailAddressList
        {
            get
            {
                if (_emailAddressList == null)
                {
                    this.recalcEmailAddressList();
                }
                return _emailAddressList;
            }
            set { _emailAddressList = value; }
        }

        public void recalcEmailAddressList()
        {
            EmailAddressList = new List<String>();
            String[] temp = UserEmailAddresses.Split(';');
            foreach (string s in temp)
            {
                EmailAddressList.Add(s.Trim().Replace(";", ""));
            }
        }

    }

    public class GroupDetailModel : BaseAuthenticatedModel
    {

        public int groupID { get; set; }
        public string groupName { get; set; }
        public string groupUsers { get; set; }

        public GroupDetailModel(int groupID, IGroupService groupService,
            IUserService userService, string email)
            : base(userService, email)
        {
            Group thisGroup = groupService.GetGroup(groupID);


            

            if (thisGroup == null)
            {
                return;
            }

            if (thisGroup.Owner == null || thisGroup.Owner.UserId != base.getUser().ID)
            {
                return;
            }

            this.groupID = thisGroup.GroupId;
            this.groupName = thisGroup.Name;

            foreach (User u in thisGroup.Users)
            {
                this.groupUsers += u.Email + "; ";
            }

        }

    }
}