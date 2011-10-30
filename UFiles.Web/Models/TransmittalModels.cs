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

        public Transmittal getTransmittal()
        {
            return _transmittal;
        }

        private void generateTransmittal(File f)
        {
            using (var context = new UFileContext())
            {
                Transmittal t = new Transmittal();

                t.Recipients = this.getRecipients();
                t.Files.Add(f);
            }

            String[] locationTemp = locationString.Split(';');
            foreach (string s in locationTemp)
            {
                try
                {
                    LocationRestriction r = new LocationRestriction();
                }
                catch (Exception e)
                {
                }
            }

        }

        private ICollection<Restriction> getRestrictions()
        {
            ICollection<Restriction> toReturn = new List<Restriction>();



            return toReturn;
        }

        private ICollection<User> getRecipients()
        {
            ICollection<User> toReturn = new List<User>();

            using (var context = new UFileContext())
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

                String[] groupTemp = recipientGroups.Split(';');
                foreach (string s in groupTemp)
                {
                    try
                    {
                        Group g = context.Groups.Where(group => group.Name == s.Trim().Replace(";", "")).Single();
                        foreach (User u in g.Users)
                        {
                            toReturn.Add(u);
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }

            }

            return toReturn;
        }

    }
}