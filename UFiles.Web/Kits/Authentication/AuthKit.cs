using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Web.Kits.Authentication;

namespace UFiles.Web.Kits.Authentication
{
    public class AuthKit : Controller
    {
        private bool isInitialized;
        private Controller currentController;
        private HttpSessionStateBase currentSession;
        private AuthState currentAuthState;

        private static string HOME_CONTROLLER_NAME = "Home";
        private static string HOME_CONTROLLER_ACTION = "Overview";
        private static RedirectToRouteResult HOME_ACTION;

        private static string AUTH_CONTROLLER_NAME = "Authentication";
        private static string AUTH_CONTROLLER_ACTION = "Login";
        private static RedirectToRouteResult AUTH_ACTION;

        public enum ViewAuthRequirement
        {
            AUTH_NONE, AUTH_LOGGED_IN, AUTH_DETERMINE, AUTH_LOGIN_HANDLER
        }

        /// <summary>
        /// Handles authentication requests and provides information about
        /// the currently authenticated user (if any).
        /// </summary>
        /// <param name="thisController">Current Controller.</param>
        public AuthKit(Controller thisController)
        {
            if (HOME_ACTION == null)
            {
                HOME_ACTION = RedirectToAction(HOME_CONTROLLER_ACTION, HOME_CONTROLLER_NAME);
            }

            if (AUTH_ACTION == null)
            {
                AUTH_ACTION = RedirectToAction(AUTH_CONTROLLER_ACTION, AUTH_CONTROLLER_NAME);
            }


            isInitialized = false;
            currentController = thisController;
        }

        /// <summary>
        /// Checks to see if the current session contains an AuthKit, and
        /// if it does not, creates a new one and inserts it into the session.
        /// </summary>
        private void setUpAuthState()
        {
            if (!isInitialized)
            {
                if (currentController.Session == null)
                {
                    return;
                }
                else
                {
                    currentSession = currentController.Session;
                }

                if (currentSession["AUTHKIT"] == null || currentSession["AUTHKIT"].GetType() != typeof(AuthState))
                {
                    currentAuthState = new AuthState();
                    currentSession["AUTHKIT"] = currentAuthState;
                }
                else
                {
                    currentAuthState = (AuthState)currentSession["AUTHKIT"];
                }

                isInitialized = true;
            }

            return;
        }

        /// <summary>
        /// Either passes back the provided view if the authentication
        /// requirements are met, otherwise provides the login view if
        /// the page requires authentication, or the home view if the page
        /// requires the session to not already be authenticated.
        /// </summary>
        /// <param name="passedView">The original view.</param>
        /// <param name="requirement">The authentication requirements for the passed view.</param>
        /// <returns>The required view to satisfy authentication requirements.</returns>
        public ActionResult DirectView(ViewResult passedView, ViewAuthRequirement requirement)
        {

            ActionResult returnedView = AUTH_ACTION;

            switch (requirement)
            {
                default:
                    break;
                case ViewAuthRequirement.AUTH_NONE:
                    returnedView = passedView;
                    break;
                case ViewAuthRequirement.AUTH_LOGGED_IN:
                    if (this.IsSessionAuthenticated())
                    {
                        returnedView = passedView;
                    }
                    else
                    {
                        returnedView = AUTH_ACTION;
                    }
                    break;
                case ViewAuthRequirement.AUTH_LOGIN_HANDLER:
                    if (this.IsSessionAuthenticated())
                    {
                        returnedView = AUTH_ACTION;
                    }
                    else
                    {
                        returnedView = passedView;
                    }
                    break;
                case ViewAuthRequirement.AUTH_DETERMINE:
                    throw new ArgumentException("You must provide a boolean argument to test against.");
                    break;
            }

            return returnedView;

        }

        /// <summary>
        /// This will return true if the current session has an authenticated 
        /// user, otherwise it will return false.
        /// </summary>
        /// <returns>If the session has a currently authenticated
        /// user.</returns>
        public bool IsSessionAuthenticated()
        {
            this.setUpAuthState();
            return currentAuthState.isLoggedIn;
        }

        /// <summary>
        /// This will return true and set up the AuthState for the
        /// session if the provided email address and password match
        /// a currently existing user, otherwise it will return false.
        /// </summary>
        /// <param name="authEmail">User's Email Address</param>
        /// <param name="authPass">User's Password</param>
        /// <returns>If the provided credentials match an existing user.</returns>
        public bool LoginUser(string authEmail, string authPass)
        {
            this.setUpAuthState();
            currentAuthState.isLoggedIn = true;

            return false;
        }

    }
}