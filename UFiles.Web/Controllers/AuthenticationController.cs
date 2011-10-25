using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using UFiles.Web.Models;
using System.Web.Security;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        private IUserService userService;
        public AuthenticationController(IUserService userService)
        {
            this.userService = userService;
        }

        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Login");
        }

        public RedirectToRouteResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

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

        [HttpPost]
        public JsonResult CheckAuth(LogOnModel authModel, string passthrough)
        {
            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "AuthenticationResults");

            try
            {

                if (!ModelState.IsValid)
                {

                    string errorTemp = "";

                    if (String.IsNullOrWhiteSpace(authModel.Email) || String.IsNullOrWhiteSpace(authModel.Password))
                    {
                        jsonDictionary.Add("FailureReason", "<p>You must fill out all of the fields.</p>");
                        Response.StatusCode = errorStatusCode;

                        return Json(jsonDictionary);
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

                string goToAddress = Url.Action("Overview", "Home");

                if (!String.IsNullOrWhiteSpace(passthrough))
                {
                    RouteValueDictionary passthroughValue = new RouteValueDictionary();
                    passthroughValue.Add("id", passthrough);
                    goToAddress = Url.Action("View", "TransmittalController", passthroughValue);
                }

                if (Membership.ValidateUser(authModel.Email, authModel.Password))
                {
                    bool remember = false;
                    if (!String.IsNullOrEmpty(authModel.RememberMe))
                    {
                        remember = true;
                    }

                    FormsAuthentication.SetAuthCookie(authModel.Email, remember);
                    jsonDictionary.Add("GoTo", goToAddress);
                    Response.StatusCode = successStatusCode;

                    return Json(jsonDictionary);
                }
                else
                {
                    jsonDictionary.Add("FailureReason", "<p>The provided email address or password is incorrect</p>");
                    Response.StatusCode = errorStatusCode;

                    return Json(jsonDictionary);
                }

            }
            catch (Exception e)
            {
                jsonDictionary.Add("FailureReason", "<p>The provided email address or password is incorrect</p>");
                Response.StatusCode = errorStatusCode;

                return Json(jsonDictionary);
            }
        }

        [HttpPost]
        public JsonResult AccountCreation(RegisterModel regModel, string passthrough)
        {

            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "ValidationResults");

            try
            {

                if (!ModelState.IsValid)
                {

                    string errorTemp = "";

                    if (String.IsNullOrWhiteSpace(regModel.Email) || String.IsNullOrWhiteSpace(regModel.FName) ||
                        String.IsNullOrWhiteSpace(regModel.LName) || String.IsNullOrWhiteSpace(regModel.Password) ||
                        String.IsNullOrWhiteSpace(regModel.ConfirmPassword))
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

                MembershipCreateStatus createStatus;
                if (Membership.GetUser(regModel.Email) == null)
                {
                    Membership.CreateUser(regModel.Email, regModel.Password, regModel.Email, null, null, true, null, out createStatus);
                    Roles.AddUsersToRole(new string[] { regModel.Email }, "Standard");
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(regModel.Email, false /* createPersistentCookie */);

                        // Set user's first name and last name.
                        try
                        {

                            UFiles.Domain.Entities.User newUser = userService.GetUserByEmail(regModel.Email);
                            newUser.FirstName = regModel.FName;
                            newUser.LastName = regModel.LName;

                            userService.SaveUser(newUser);

                        }
                        catch (Exception e)
                        {
                            // Give up on giving the user a first name and last name.
                        }

                        UrlHelper url = new UrlHelper(Request.RequestContext);
                        jsonDictionary.Add("GoTo", url.RouteUrl("Home"));
                    }
                    else
                    {
                        jsonDictionary.Add("FailureReason", createStatus.ToString());
                        Response.StatusCode = errorStatusCode;

                        return Json(jsonDictionary);
                    }
                }
                else
                {
                    jsonDictionary.Add("FailureReason", "Email already exists");
                    Response.StatusCode = errorStatusCode;

                    return Json(jsonDictionary);
                }

                string goToAddress = Url.Action("Overview", "Home");

                if (!String.IsNullOrWhiteSpace(passthrough))
                {
                    RouteValueDictionary passthroughValue = new RouteValueDictionary();
                    passthroughValue.Add("id", passthrough);
                    goToAddress = Url.Action("View", "Transmittal", passthroughValue);
                }

                jsonDictionary.Add("GoTo", goToAddress);
                Response.StatusCode = successStatusCode;

                return Json(jsonDictionary);
            }
            catch (Exception e)
            {
                jsonDictionary.Add("FailureReason", "<p>Something went wrong. Please try again later.</p>");
                Response.StatusCode = errorStatusCode;

                return Json(jsonDictionary); ;
            }

        }

    }
}
