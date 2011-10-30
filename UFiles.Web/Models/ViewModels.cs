using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Models
{
    public class OverviewModel : BaseAuthenticatedModel
    {
        public List<TransmittalListingModel> RecentlySentTransmittals { get; set; }
        public List<TransmittalListingModel> RecentlyReceivedTransmittals { get; set; }
        public List<Type> RestrictionClassList { get; set; }

        public TransmittalOverviewModel preloadedOverview { get; set; }

        public OverviewModel(IUserService userService, ITransmittalService transmittalService,
            string email)
            : base(userService, email)
        {
            RecentlySentTransmittals = new List<TransmittalListingModel>();
            RecentlyReceivedTransmittals = new List<TransmittalListingModel>();
            RestrictionClassList = new List<Type>();


            try
            {
                using (var context = new UFileContext())
                {
                    User thisUser = context.Users.Where<User>(u => u.Email == email).Single();

                    IEnumerable<Transmittal> receivedTransmittals = (from transmittal in context.Transmittals
                                                                     where transmittal.Recipients.FirstOrDefault().Email == email
                                                                     select transmittal);


                    foreach (Transmittal t in receivedTransmittals)
                    {
                        t.Files = (from transmittal in context.Transmittals
                                   where transmittal.TransmittalId == t.TransmittalId
                                   select transmittal.Files).First();

                        IEnumerable<ICollection<Restriction>> r = (from transmittal in context.Transmittals
                                                             where transmittal.TransmittalId == t.TransmittalId
                                                             select transmittal.Files.FirstOrDefault().Restrictions);

                        t.Files.ToArray()[0].Restrictions = r.ToArray()[0];

                        TransmittalListingModel temp = new TransmittalListingModel(t, true);
                        RecentlyReceivedTransmittals.Add(temp);

                        if (preloadedOverview == null)
                        {
                            preloadedOverview = new TransmittalOverviewModel(t);
                        }

                    }

                    foreach (Transmittal t in (from transmittal in context.Transmittals
                                               where transmittal.Sender.Email == email
                                               select transmittal))
                    {
                        t.Files = (from transmittal in context.Transmittals
                                   where transmittal.TransmittalId == t.TransmittalId
                                   select transmittal.Files).ToArray()[0];

                        TransmittalListingModel temp = new TransmittalListingModel(t, true);
                        RecentlySentTransmittals.Add(temp);
                    }

                }

            }
            catch (Exception e) { 
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
                User thisUser = context.Users.Where(u => u.Email == email).Single();

                foreach (Group thisGroup in context.Groups.Where(g => g.Owner.UserId == thisUser.UserId))
                {
                    thisGroup.Users = (from g in context.Groups
                                       where g.GroupId == thisGroup.GroupId
                                       select g.Users).Single();

                    GroupListingModel temp = new GroupListingModel(thisGroup);
                    this.groupList.Add(temp);
                }

            }

        }

    }
}