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
        public JsonResult CheckAuth(LogOnModel authModel, string passthrough)
        {
            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "AuthenticationResults");

            if (!ModelState.IsValid)
            {

                string errorTemp = "";

                if (String.IsNullOrWhiteSpace(authModel.Email) || String.IsNullOrWhiteSpace(authModel.Password))
                {
                    jsonDictionary.Add("FailureReason", "<p>You must fill out all of the fields.</p>");
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
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

                jsonReply = Json(jsonDictionary);

                return jsonReply;

            }

            string goToAddress = Url.Action("Overview", "HomeController");

            if (!String.IsNullOrWhiteSpace(passthrough))
            {
                RouteValueDictionary passthroughValue = new RouteValueDictionary();
                passthroughValue.Add("id", passthrough);
                goToAddress = Url.Action("View", "TransmittalController", passthroughValue);
            }

            if (Membership.ValidateUser(authModel.Email, authModel.Password))
            {
                FormsAuthentication.SetAuthCookie(authModel.Email, authModel.RememberMe);
                jsonDictionary.Add("GoTo", goToAddress);
                Response.StatusCode = successStatusCode;

                jsonReply = Json(jsonDictionary);
                return jsonReply;
            }
            else
            {
                jsonDictionary.Add("FailureReason", "The provided email address or password is incorrect");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }
        }

        [HttpPost, RequireHttps]
        public JsonResult AccountCreation(RegisterModel regModel, string passthrough)
        {

            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "ValidationResults");

            if (!ModelState.IsValid)
            {

                string errorTemp = "";

                if (String.IsNullOrWhiteSpace(regModel.Email) || String.IsNullOrWhiteSpace(regModel.FName) ||
                    String.IsNullOrWhiteSpace(regModel.LName) || String.IsNullOrWhiteSpace(regModel.Password) ||
                    String.IsNullOrWhiteSpace(regModel.ConfirmPassword))
                {
                    jsonDictionary.Add("FailureReason", "<p>You must fill out all of the fields.</p>");
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
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

                jsonReply = Json(jsonDictionary);

                return jsonReply;

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
                    jsonDictionary.Add("FailureReason", createStatus.ToString());
                    Response.StatusCode = errorStatusCode;

                    jsonReply = Json(jsonDictionary);

                    return jsonReply;
                }
            }
            else
            {
                jsonDictionary.Add("FailureReason", "Email already exists");
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }

            string goToAddress = Url.Action("Overview", "HomeController");

            if (!String.IsNullOrWhiteSpace(passthrough))
            {
                RouteValueDictionary passthroughValue = new RouteValueDictionary();
                passthroughValue.Add("id", passthrough);
                goToAddress = Url.Action("View", "TransmittalController", passthroughValue);
            }

            jsonDictionary.Add("GoTo", goToAddress);
            Response.StatusCode = successStatusCode;

            jsonReply = Json(jsonDictionary);
            return jsonReply;
        }

    }
}
