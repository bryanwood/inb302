using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Web.Models
{
    public class BaseAuthenticatedModel
    {

        private IUserService userService;
        // Models
        private UserModel user;

        public BaseAuthenticatedModel(IUserService userService, string email)
        {
            this.userService = userService;
            User thisUser = null;
            try
            {
                thisUser = userService.GetUserByEmail(email);

            }
            catch (Exception e)
            {
                thisUser = new User();
                thisUser.Email = "N/A";
                thisUser.FirstName = "N/A";
                thisUser.LastName = "N/A";
            }

            user = new UserModel(thisUser);
        }

        public UserModel getUser()
        {
            return user;
        }

    }
}