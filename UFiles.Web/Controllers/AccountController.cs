using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UFiles.Web.Models;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Web.Controllers
{
    public class AccountController : Controller
    {

        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public ActionResult Settings()
        {
            BaseAuthenticatedModel model = new BaseAuthenticatedModel(userService, User.Identity.Name);

            return View(model);
        }

        [Authorize, HttpPost]
        public JsonResult ChangeProfileInformation(ChangeProfileInformationModel model)
        {


            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "ChangeProfileInformation");

            if (!ModelState.IsValid)
            {

                string errorTemp = "";

                if (String.IsNullOrWhiteSpace(model.Email) || String.IsNullOrWhiteSpace(model.FName) ||
                    String.IsNullOrWhiteSpace(model.LName))
                {
                    jsonDictionary.Add("FailureReason", "<p>You must fill out all of the fields.</p>");
                    Response.StatusCode = errorStatusCode;

                    return Json(jsonDictionary); ;
                }

                foreach (KeyValuePair<string, ModelState> i in ModelState.AsEnumerable())
                {
                    foreach (ModelError e in i.Value.Errors)
                    {
                        errorTemp += "<p>" + e.ErrorMessage + "</p>";
                    }
                }

                jsonDictionary.Add("FailureReason", errorTemp);
                Response.StatusCode = errorStatusCode;

                return Json(jsonDictionary);

            }
            try
            {
                UFiles.Domain.Entities.User newUser = userService.GetUserByEmail(User.Identity.Name);
                newUser.Email = model.Email;
                newUser.FirstName = model.FName;
                newUser.LastName = model.LName;

                userService.SaveUser(newUser);

                if (model.Email != User.Identity.Name)
                {
                    FormsAuthentication.SignOut();

                    jsonDictionary.Add("Success", "True");
                    jsonDictionary.Add("GoTo", Url.Action("Login", "Authentication"));
                    Response.StatusCode = successStatusCode;

                    return Json(jsonDictionary);
                }
            }
            catch (Exception e)
            {
                jsonDictionary.Add("FailureReason", "<p>Something went wrong.</p>");
                Response.StatusCode = errorStatusCode;

                return Json(jsonDictionary); ;
            }

            jsonDictionary.Add("Success", "True");
            jsonDictionary.Add("GoTo", Url.Action("Settings"));
            Response.StatusCode = successStatusCode;

            return Json(jsonDictionary);

        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
