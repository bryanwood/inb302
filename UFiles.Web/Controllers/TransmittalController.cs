using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Web.Models;

namespace UFiles.Web.Controllers
{
    public class TransmittalController : Controller
    {
        private ITransmittalService transmittalService;
        private IUserService userService;

        public TransmittalController(ITransmittalService transmittalService, IUserService userService)
        {
            this.transmittalService = transmittalService;
            this.userService = userService;
        }

        [Authorize]
        public ActionResult SendFile()
        {
            BaseAuthenticatedModel model = new BaseAuthenticatedModel(userService, User.Identity.Name);
            return View(model);
        }

        [Authorize, HttpPost]
        public JsonResult Upload(TransmittalSendModel model)
        {
            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "SendFile");

            if (!ModelState.IsValid)
            {

                string errorTemp = "";

                if (String.IsNullOrWhiteSpace(model.recipientEmail) && String.IsNullOrWhiteSpace(model.recipientGroups))
                {
                    jsonDictionary.Add("FailureReason", "<p>You must fill out either an email address or a group to send to.</p>");
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

            jsonDictionary.Add("Success", "True");

            Response.StatusCode = successStatusCode;
            return Json(jsonDictionary);

        }

        [Authorize]
        public ActionResult List()
        {
            var user = userService.GetUserByEmail(User.Identity.Name);
            var transmittals = transmittalService.GetTransmittalsByUser(user);

            return View(transmittals);
        }

        //
        // GET: /File/
        [Authorize]
        public ActionResult View(int id)
        {
            var user = userService.GetUserByEmail(User.Identity.Name);

            var transmittal = transmittalService.GetTransmittalById(id);

            //Check if the user is the sender or recipient
            if (transmittal.Recipients.Contains(user) || transmittal.Sender==user)
            {
                return View(transmittal);              
            }
            
            return RedirectToAction("Unavailable");
        }

        public ActionResult Unavailable()
        {
            return View();
        }
    }
}
