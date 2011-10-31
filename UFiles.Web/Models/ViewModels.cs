using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Domain.Concrete;
using System.Collections;

namespace UFiles.Web.Models
{
    public class OverviewModel : BaseAuthenticatedModel
    {
        public List<TransmittalListingModel> RecentlySentTransmittals { get; set; }
        public List<TransmittalListingModel> RecentlyReceivedTransmittals { get; set; }
        public List<Type> RestrictionClassList { get; set; }

        public TransmittalOverviewModel preloadedOverview { get; set; }

        public OverviewModel(IUserService userService, IFileService fileService, ITransmittalService transmittalService,
            string email, string ipAddress)
            : base(userService, email)
        {
            RecentlySentTransmittals = new List<TransmittalListingModel>();
            RecentlyReceivedTransmittals = new List<TransmittalListingModel>();
            RestrictionClassList = new List<Type>();
            User thisUser = userService.GetUserByEmail(email);

                   
            var receivedTransmittals = transmittalService.GetTransmittalsByRecipient(thisUser.UserId);
            foreach (Transmittal t in receivedTransmittals)
            {
                if (t.Sent)
                {
                    if (fileService.UserCanAccessFile(t.Files.First().FileId, thisUser.UserId, 4051, ipAddress))
                    {
                        TransmittalListingModel temp = new TransmittalListingModel(t, true);
                        RecentlyReceivedTransmittals.Add(temp);

                        if (preloadedOverview == null)
                        {
                            preloadedOverview = new TransmittalOverviewModel(t);
                        }
                    }
                }

            }

            foreach (Transmittal t in transmittalService.GetTransmittalsBySender(thisUser.UserId))
            {
                if (t.Sent)
                {
                        TransmittalListingModel temp = new TransmittalListingModel(t, false);
                        RecentlySentTransmittals.Add(temp);
                }
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

            using (var context = new UFileContext())
            {
                User thisUser = userService.GetUserByEmail(email);

                foreach (Group thisGroup in groupService.GetGroupsByOwner(thisUser))
                {
                    GroupListingModel temp = new GroupListingModel(thisGroup);
                    this.groupList.Add(temp);
                }

            }

        }

    }
}