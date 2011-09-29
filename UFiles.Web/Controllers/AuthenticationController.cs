using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text.RegularExpressions;
using UFiles.Web.Models;
using System.Web.Security;

namespace UFiles.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public AuthenticationController()
        {

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

        [HttpPost, RequireHttps]
        public JsonResult AccountCreation(RegisterModel regModel, string passthrough)
        {

            int errorStatusCode = 400;
            int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "ValidationResults");

            if (!ModelState.IsValid)
            {

                // Has the user entered a valid email address?
                if (ModelState["Email"].Errors.Count > 0)
                {
                    string errorTemp = "";

                    foreach(ModelError i in ModelState["Email"].Errors)
                    {
                        errorTemp = errorTemp + "<p>" + i.ErrorMessage + "</p>";
                    }
                    jsonDictionary.Add("DidPass", "false");
                    jsonDictionary.Add("FailedField", "Email");
                    jsonDictionary.Add("FailureReason", errorTemp);
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }

                // Has the user entered a valid first name?
                if (ModelState["FName"].Errors.Count > 0)
                {
                    string errorTemp = "";

                    foreach (ModelError i in ModelState["FName"].Errors)
                    {
                        errorTemp = errorTemp + "<p>" + i.ErrorMessage + "</p>";
                    }
                    jsonDictionary.Add("DidPass", "false");
                    jsonDictionary.Add("FailedField", "FirstName");
                    jsonDictionary.Add("FailureReason", errorTemp);
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }

                // Has the user entered a valid last name?
                if (ModelState["LName"].Errors.Count > 0)
                {
                    string errorTemp = "";

                    foreach (ModelError i in ModelState["LName"].Errors)
                    {
                        errorTemp = errorTemp + "<p>" + i.ErrorMessage + "</p>";
                    }
                    jsonDictionary.Add("DidPass", "false");
                    jsonDictionary.Add("FailedField", "LastName");
                    jsonDictionary.Add("FailureReason", errorTemp);
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }

                // Has the user entered in a valid password twice?
                if (ModelState["ConfirmPassword"].Errors.Count > 0 && ModelState["Password"].Errors.Count > 0)
                {
                    string errorTemp = "";

                    foreach (ModelError i in ModelState["Password"].Errors)
                    {
                        errorTemp = errorTemp + "<p>" + i.ErrorMessage + "</p>";
                    }

                    foreach (ModelError i in ModelState["ConfirmPassword"].Errors)
                    {
                        errorTemp = errorTemp + "<p>" + i.ErrorMessage + "</p>";
                    }
                    jsonDictionary.Add("DidPass", "false");
                    jsonDictionary.Add("FailedField", "PasswordMatch");
                    jsonDictionary.Add("FailureReason", errorTemp);
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }
            }

            MembershipCreateStatus createStatus;
            if (Membership.GetUser(regModel.Email) == null)
            {
                Membership.CreateUser(regModel.Email, regModel.Password, regModel.Email, null, null, true, null, out createStatus);
                Roles.AddUsersToRole(new string[] { regModel.Email }, "Standard");
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(regModel.Email, false /* createPersistentCookie */);
                    UrlHelper url = new UrlHelper(Request.RequestContext);
                    jsonDictionary.Add("GoTo", url.RouteUrl("Home"));
                }
                else
                {
                    jsonDictionary.Add("DidPass", "false");
                    jsonDictionary.Add("FailureReason", createStatus.ToString());
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }
            }
            else
            {
                jsonDictionary.Add("DidPass", "false");
                jsonDictionary.Add("FailureReason", "Email already exists");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }

            jsonDictionary.Add("DidPass", "true");
            Response.StatusCode = successStatusCode;

            jsonReply = Json(jsonDictionary);
            return jsonReply;
        }

    }
}
