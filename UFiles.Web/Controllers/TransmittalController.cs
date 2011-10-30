using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Web.Models;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Controllers
{

    public class TransmittalController : Controller
    {
        private UFileContext db = new UFileContext();
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
            const int successStatusCode = 200;

            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

            jsonDictionary.Add("ReplyingFor", "SendFile");

            if (Request.Files.Count < 1)
            {
                {
                    jsonDictionary.Add("FailureReason", "<p>You must select a file to send.</p>");
                    jsonDictionary.Add("Success", "false");
                    Response.StatusCode = successStatusCode;

                    return Json(jsonDictionary); ;
                }
            }

            if (String.IsNullOrWhiteSpace(model.recipientEmail) && String.IsNullOrWhiteSpace(model.recipientGroups))
            {
                jsonDictionary.Add("FailureReason", "<p>You must fill out either an email address or a group to send to.</p>");
                jsonDictionary.Add("Success", "false");
                Response.StatusCode = successStatusCode;

                return Json(jsonDictionary); ;
            }

            if (!ModelState.IsValid)
            {

                string errorTemp = "";

                foreach (KeyValuePair<string, ModelState> i in ModelState.AsEnumerable())
                {
                    foreach (ModelError e in i.Value.Errors)
                    {
                        errorTemp += "<p>" + e.ErrorMessage + "</p>";
                    }
                }

                jsonDictionary.Add("FailureReason", errorTemp);
                jsonDictionary.Add("Success", "false");
                Response.StatusCode = successStatusCode;

                return Json(jsonDictionary);

            }

            try
            {
                using (var context = new UFileContext())
                {

                    User thisUser = context.Users.Where(u => u.Email == User.Identity.Name).Single();

                    File file = new File();
                    file.FileData = new byte[Request.Files[0].ContentLength];
                    file.Name = Request.Files[0].FileName;
                    file.Size = Request.Files[0].ContentLength;
                    file.ContentType = Request.Files[0].ContentType;
                    file.DateCreated = DateTime.Now;
                    file.Owner = thisUser;
                    file.OwnerId = thisUser.UserId;

                    IAsyncResult result = Request.Files[0].InputStream.BeginRead(file.FileData, 0,
                        Request.Files[0].ContentLength, null, file);
                    Request.Files[0].InputStream.EndRead(result);

                    file = context.Files.Add(file);
                    context.SaveChanges();

                    Transmittal t = model.getTransmittal(file, thisUser, context);

                    context.Transmittals.Add(t);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                jsonDictionary.Add("FailureReason", "Something went wrong");
                jsonDictionary.Add("Success", "false");
                Response.StatusCode = successStatusCode;

                return Json(jsonDictionary);
            }

            jsonDictionary.Add("Success", "true");

            Response.StatusCode = successStatusCode;
            return Json(jsonDictionary);

        }

        [Authorize]
        public ActionResult List()
        {
            return null;
        }

        //
        // GET: /File/
        [Authorize]
        public ActionResult View(int id)
        {
            return null;
        }

        public ActionResult Unavailable()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost()
        {
            var transmittal = new Transmittal();
            transmittal.Sender = db.Users.Where(u => u.Email == User.Identity.Name).Single();
            db.Transmittals.Add(transmittal);
            db.SaveChanges();
            return RedirectToAction("AddFile", new { id = transmittal.TransmittalId });
        }
        public ActionResult AddFile(int id)
        {
            return View(db.Transmittals.Find(id));
        }
        [HttpPost]
        public ActionResult AddFile(Transmittal transmittal, HttpPostedFileBase file)
        {
            var dfile = new File();
            dfile.Owner = db.Users.Where(u => u.Email == User.Identity.Name).Single();
            dfile.Revoked = false;
            dfile.Name = file.FileName;
            dfile.DateCreated = DateTime.Now;

            dfile.ContentType = file.ContentType;
            dfile.Size = file.ContentLength;
            dfile.FileData = new byte[file.ContentLength];

            file.InputStream.Read(dfile.FileData, 0, file.ContentLength);

            db.Files.Add(dfile);
            db.SaveChanges();
            return RedirectToAction("AddRestriction", new { id = dfile.FileId });
        }
        public ActionResult AddRestriction(int id)
        {
            //TODO: Add Restrictions View Model needs to be worked out
            return View();
        }
        [HttpPost]
        public ActionResult AddRestriction(File file)
        {
            //TODO: Adding Restrictions from the View Model
            return RedirectToAction("AddRestriction", new { id = file.FileId });
        }
        [HttpPost]
        public ActionResult Send(int id)
        {
            //TODO: Email notifications
            var transmittal = db.Transmittals.Find(id);
            transmittal.Sent = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
