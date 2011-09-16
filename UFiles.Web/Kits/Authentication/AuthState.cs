using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFiles.Web.Kits.Authentication
{
    internal class AuthState
    {

        public bool isLoggedIn { get; set; }
        public int userID { get; set; }
        public string userEmailAddress { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }

        public AuthState()
        {
            this.isLoggedIn = false;
            this.userID = -1;
            this.userEmailAddress = "";
            this.userFirstName = "";
            this.userLastName = "";
        }

    }
}