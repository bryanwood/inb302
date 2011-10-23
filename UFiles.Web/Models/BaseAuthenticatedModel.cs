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
            User thisUser = userService.GetUserByEmail(email);

            user = new UserModel(thisUser);
        }

        public UserModel getUser()
        {
            return user;
        }

    }
}