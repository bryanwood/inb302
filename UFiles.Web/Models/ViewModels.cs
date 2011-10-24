using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Web.Models
{
    public class OverviewModel : BaseAuthenticatedModel
    {
        public List<TransmittalListingModel> RecentlySentTransmittals { get; set; }
        public List<TransmittalListingModel> RecentlyReceivedTransmittals { get; set; }

        public OverviewModel(IUserService userService, ITransmittalService transmittalService,
            string email): base(userService, email)
        {
            RecentlySentTransmittals = new List<TransmittalListingModel>();
            RecentlyReceivedTransmittals = new List<TransmittalListingModel>();

            foreach(Transmittal t in transmittalService.GetTransmittalsByUser(
                userService.GetUserByEmail(email))) {
                    TransmittalListingModel temp = new TransmittalListingModel(t);
            
            }
        }
    }

    public class GroupViewModel : BaseAuthenticatedModel
    {

        public List<GroupListingModel> groupList { get; set; }

        public GroupViewModel(IUserService userService, IGroupService groupService, string email)
            : base(userService, email)
        {
            groupList = new List<GroupListingModel>();

            foreach (Group g in groupService.GetGroupsByOwner(userService.GetUserByEmail(email)))
            {
                GroupListingModel temp = new GroupListingModel(g);
                this.groupList.Add(temp);
            }

        }

    }
}