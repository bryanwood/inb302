using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Web.Models
{
    public class TransmittalListingModel
    {
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime SentDate { get; set; }
        public string DownloadLink { get; set; }
    }

    public class TransmittalOverview
    {
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime SentDate { get; set; }
        public string DownloadLink { get; set; }
    }

    public class TransmittalSendModel
    {
        // File to be sent
        [Required(ErrorMessage = "You must select a file to send")]
        public Byte[] uploadedFile { get; set; }
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