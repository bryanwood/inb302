using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Web.Models
{
    public class OverviewModel
    {
        public UserModel LoggedInUser { get; set; }
        public List<TransmittalListingModel> RecentlySentTransmittals { get; set; }
        public List<TransmittalListingModel> RecentlyReceivedTransmittals { get; set; }

        public OverviewModel()
        {
            LoggedInUser = new UserModel();
            RecentlySentTransmittals = new List<TransmittalListingModel>();
            RecentlyReceivedTransmittals = new List<TransmittalListingModel>();
        }
    }
}