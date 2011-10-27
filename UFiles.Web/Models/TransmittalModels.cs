using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFiles.Domain.Entities;

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
        public string DownloadLink { get; set; }

        public TransmittalOverviewModel(Transmittal t)
        {
            this.FileName = t.Files.ToArray()[0].Name;
            this.Sender = t.Sender.Email;
            this.SentDate = t.Files.ToArray()[0].DateCreated;
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

    }
}