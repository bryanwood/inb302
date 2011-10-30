using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Entities;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Models
{
    public class TransmittalListingModel
    {
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime SentDate { get; set; }
        public string DownloadLink { get; set; }

        public TransmittalListingModel(Transmittal t, bool recieved)
        {
            this.FileName = t.Files.ToArray()[0].Name;

            if (recieved)
            {
                this.Email = t.Sender.Email;
            }
            else
            {
                if (t.Recipients.Count > 1)
                {
                    this.Email = "many recipients";
                }
                else
                {
                    this.Email = t.Recipients.ToArray()[0].Email;
                }
            }

            this.SentDate = t.Files.ToArray()[0].DateCreated;
        }
    }

    public class TransmittalOverviewModel
    {
        public string FileName { get; set; }
        public string Sender { get; set; }
        public DateTime SentDate { get; set; }
        public List<UserRestriction> UserRestrictions { get; set; }
        public List<LocationRestriction> LocationRestrictions { get; set; }
        public List<IPRestriction> IPRestrictions { get; set; }
        public List<GroupRestriction> GroupRestrictions { get; set; }
        public List<TimeRangeRestriction> TimeRangeRestrictions { get; set; }
        public string DownloadLink { get; set; }

        public TransmittalOverviewModel(Transmittal t)
        {
            this.FileName = t.Files.ToArray()[0].Name;
            this.Sender = t.Sender.Email;
            this.SentDate = t.Files.ToArray()[0].DateCreated;
            // Restrictions
            this.UserRestrictions = t.Files.ToArray()[0].Restrictions.OfType<UserRestriction>().ToList();
            this.LocationRestrictions = t.Files.ToArray()[0].Restrictions.OfType<LocationRestriction>().ToList();
            this.IPRestrictions = t.Files.ToArray()[0].Restrictions.OfType<IPRestriction>().ToList();
            this.GroupRestrictions = t.Files.ToArray()[0].Restrictions.OfType<GroupRestriction>().ToList();
            this.TimeRangeRestrictions = t.Files.ToArray()[0].Restrictions.OfType<TimeRangeRestriction>().ToList();
        }
    }

    public class TransmittalSendModel
    {
        // Simple unparsed text
        public string recipientEmail { get; set; }
        public string recipientGroups { get; set; }
        // Which recipient string we're using to send
        [Required]
        public string sendTo { get; set; }
        // Restrictions
        public string emailRestriction { get; set; }
        public string groupRestriction { get; set; }
        public string locationString { get; set; }
        public string ipString { get; set; }
        // Restrictions -- Time
        public String timeIsEnabled { get; set; }
        public int startTimeHour { get; set; }
        public int startTimeMinute { get; set; }
        public string startTimeDate { get; set; }
        public int endTimeHour { get; set; }
        public int endTimeMinute { get; set; }
        public string endTimeDate { get; set; }

        private Transmittal _transmittal { get; set; }

        public Transmittal getTransmittal(File f, User sender)
        {
            this.generateTransmittal(f, sender);
            return _transmittal;
        }

        private void generateTransmittal(File f, User sender)
        {
            Transmittal t = new Transmittal();
            t.Sender = sender;
            t.SenderId = sender.UserId;
            t.Sent = true;
            t.Files = new List<File>();

            t.Recipients = new List<User>();
            t.Recipients.ToList().AddRange(this.getRecipients());
            f.Restrictions = new List<Restriction>();
            f.Restrictions.ToList().AddRange(this.getRestrictions());
            t.Files.Add(f);

            _transmittal = t;

        }

        private ICollection<Restriction> getRestrictions()
        {
            ICollection<Restriction> toReturn = new List<Restriction>();

            using (var context = new UFileContext())
            {

                #region Email Restrictions

                if (!String.IsNullOrWhiteSpace(emailRestriction))
                {
                    String[] emailTemp = emailRestriction.Split(';');
                    UserRestriction uR = new UserRestriction();
                    uR.Users = new List<User>();
                    foreach (string s in emailTemp)
                    {
                        try
                        {
                            User u = context.Users.Where(user => user.Email == s.Trim().Replace(";", "")).Single();
                            uR.Users.Add(u);
                        }
                        catch (Exception e)
                        {
                        }
                    }

                    uR = (UserRestriction)context.Restrictions.Add(uR);
                    toReturn.Add(uR);


                #endregion

                    #region Group Restrictions

                    if (!String.IsNullOrWhiteSpace(groupRestriction))
                    {
                        String[] groupTemp = groupRestriction.Split(';');
                        GroupRestriction gR = new GroupRestriction();
                        gR.Groups = new List<Group>();
                        foreach (string s in groupTemp)
                        {
                            try
                            {
                                Group g = context.Groups.Where(group => group.Name == s.Trim().Replace(";", "")).Single();
                                gR.Groups.Add(g);
                            }
                            catch (Exception e)
                            {
                            }
                        }

                        gR = (GroupRestriction)context.Restrictions.Add(gR);
                        toReturn.Add(gR);
                    }

                    #endregion

                }

                #region Location Restrictions

                if (!String.IsNullOrWhiteSpace(locationString))
                {
                    String[] locationTemp = locationString.Split(';');
                    LocationRestriction lR = new LocationRestriction();
                    lR.Locations = new List<Location>();
                    foreach (string s in locationTemp)
                    {
                        try
                        {
                            Location l = new Location();
                            l.PostCode = Int32.Parse(s).ToString();
                            l = context.Locations.Add(l);
                            lR.Locations.Add(l);
                        }
                        catch (Exception e)
                        {
                        }
                    }

                    lR = (LocationRestriction)context.Restrictions.Add(lR);
                    toReturn.Add(lR);
                }

                #endregion

                #region IP Address Restrictions


                if (!String.IsNullOrWhiteSpace(ipString))
                {
                    String[] ipTemp = ipString.Split(';');
                    IPRestriction ipR = new IPRestriction();
                    ipR.IPAddress = new List<IPAddress>();
                    foreach (string s in ipTemp)
                    {
                        try
                        {
                            IPAddress ip = new IPAddress();
                            ip.IP = s;
                            ip = context.IPAddresses.Add(ip);

                            ipR.IPAddress.Add(ip);
                        }
                        catch (Exception e)
                        {
                        }
                    }

                    ipR = (IPRestriction)context.Restrictions.Add(ipR);
                    toReturn.Add(ipR);
                }

                #endregion

                #region Time Restriction

                if (!String.IsNullOrWhiteSpace(timeIsEnabled))
                {

                    TimeRangeRestriction trR = new TimeRangeRestriction();
                    trR.TimeRanges = new List<TimeRange>();

                    TimeRange tR = new TimeRange();

                    DateTime start = DateTime.Parse(startTimeDate);
                    start = start.AddHours(startTimeHour);
                    start = start.AddMinutes(startTimeMinute);

                    DateTime end = DateTime.Parse(endTimeDate);
                    end = end.AddHours(endTimeHour);
                    end = end.AddMinutes(endTimeHour);

                    tR.Start = start;
                    tR.End = end;

                    tR = context.TimeRanges.Add(tR);

                    trR.TimeRanges.Add(tR);

                    trR = (TimeRangeRestriction)context.Restrictions.Add(trR);

                    toReturn.Add(trR);

                }

                #endregion

                context.SaveChanges();

            }

            return toReturn;
        }

        private ICollection<User> getRecipients()
        {
            ICollection<User> toReturn = new List<User>();

            using (var context = new UFileContext())
            {

                if (!String.IsNullOrWhiteSpace(recipientEmail))
                {
                    String[] emailTemp = recipientEmail.Split(';');
                    foreach (string s in emailTemp)
                    {
                        try
                        {
                            User u = context.Users.Where(user => user.Email == s.Trim().Replace(";", "")).Single();
                            toReturn.Add(u);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }

                if (!String.IsNullOrWhiteSpace(recipientGroups))
                {
                    String[] groupTemp = recipientGroups.Split(';');
                    foreach (string s in groupTemp)
                    {
                        try
                        {
                            Group thisGroup = context.Groups.Where(group => group.Name == s.Trim().Replace(";", "")).Single();
                            thisGroup.Users = (from g in context.Groups
                                               where g.GroupId == thisGroup.GroupId
                                               select g.Users).Single();
                            foreach (User u in thisGroup.Users)
                            {
                                toReturn.Add(u);
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }

            }

            return toReturn;
        }

    }
}