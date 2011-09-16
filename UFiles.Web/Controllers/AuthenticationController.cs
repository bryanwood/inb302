using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using UFiles.Web.Kits.Authentication;
using System.Text.RegularExpressions;

namespace UFiles.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        private AuthKit authKit;

        public AuthenticationController()
        {
            authKit = new AuthKit(this);

        }

        [RequireHttps]
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Login");
        }

        [RequireHttps]
        public ViewResult Login(string authFail = "", string passthrough = "")
        {
            RouteValueDictionary routeParams = new RouteValueDictionary();
            ViewBag.AuthFail = false;
            ViewBag.HasPassthrough = false;

            if (authFail.Contains('1'))
                ViewBag.AuthFail = true;

            if (passthrough.Length > 0)
            {
                ViewBag.HasPassthrough = true;
                ViewBag.Passthrough = passthrough;

                routeParams.Add("passthrough", passthrough);
            }

            ViewBag.PassthroughRoute = routeParams;

            return View();
        }

        [RequireHttps]
        public ViewResult Create(string passthrough = "")
        {
            RouteValueDictionary routeParams = new RouteValueDictionary();
            ViewBag.HasPassthrough = false;

            if (passthrough.Length > 0)
            {
                ViewBag.HasPassthrough = true;
                ViewBag.Passthrough = passthrough;

                routeParams.Add("passthrough", passthrough);
            }

            ViewBag.PassthroughRoute = routeParams;

            return View();
        }

        [HttpPost, RequireHttps]
        public RedirectToRouteResult CheckAuth(string authEmail, string authPass, string passthrough)
        {
            // If the user's credentials check out, either redirect to
            // the home page, or if they've specified a passthrough address,
            // head to that download page instead.
            // TODO: Make passthrough actually do something.
            if (authKit.LoginUser(authEmail, authPass))
            {
                return RedirectToAction("Login");
            }
            else
            {
                // User's credentials didn't check out, so we'll redirect
                // back to the login page, but we'll remember the passthrough
                // address for when they actually authenticate.
                RouteValueDictionary routeParams = new RouteValueDictionary();
                routeParams.Add("authFail", "1");
                if (!String.IsNullOrWhiteSpace(passthrough))
                {
                    routeParams.Add("passthrough", passthrough);
                }
                return RedirectToAction("Login", routeParams);
            }
        }

        [HttpPost, RequireHttps]
        public JsonResult AccountCreation(String authEmail = "", String authFName = "", String authLName = "",
            String authPass = "", String authConfirm = "", String passthrough = "")
        {

            int errorStatusCode = 400;
            int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "ValidationResults");

            Regex regex;

            regex = new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

            // Has the user entered a valid email address?
            if (String.IsNullOrWhiteSpace(authEmail) && !regex.IsMatch(authEmail))
            {
                jsonDictionary.Add("DidPass", "false");
                jsonDictionary.Add("FailedField", "Email");
                jsonDictionary.Add("FailureReason", "You must enter a valid email address.");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }


            regex = new Regex("^[\\D]*$");

            // Has the user entered a valid first name?
            if (String.IsNullOrWhiteSpace(authFName) && !regex.IsMatch(authFName))
            {
                jsonDictionary.Add("DidPass", "false");
                jsonDictionary.Add("FailedField", "FirstName");
                jsonDictionary.Add("FailureReason", "You must enter a valid first name.");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }

            // Has the user entered a valid last name?
            if (String.IsNullOrWhiteSpace(authLName) && !regex.IsMatch(authLName))
            {
                jsonDictionary.Add("DidPass", "false");
                jsonDictionary.Add("FailedField", "LastName");
                jsonDictionary.Add("FailureReason", "You must enter a valid last name.");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }

            // Has the user entered in a valid password twice?
            if (String.IsNullOrWhiteSpace(authPass) && String.IsNullOrWhiteSpace(authConfirm)
                && !authPass.Equals(authConfirm, StringComparison.CurrentCulture))
            {
                jsonDictionary.Add("DidPass", "false");
                jsonDictionary.Add("FailedField", "PasswordMatch");
                jsonDictionary.Add("FailureReason", "The two password fields must match each other.");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }

            // If we've made it to here, then we'll create the account, and redirect
            // the user's browser to the home page, or to the download page if they've
            // supplied a passthrough address.
            // TODO: Actually create an account.
            // TODO: Make passthrough address do something.

            jsonDictionary.Add("DidPass", "true");
            Response.StatusCode = successStatusCode;

            jsonReply = Json(jsonDictionary);

            return jsonReply;
        }

    }
}
