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
using System.Net;

namespace UFiles.Web.Controllers
{
    public class JsonReply
    {
        public string ReplyingFor { get; set; }
        public string FailureReason { get; set; }
        public string Success { get; set; }
        public string GoTo { get; set; }
    }
    public class TransmittalController : Controller
    {
        private ITransmittalService transmittalService;
        private IUserService userService;
        private IFileService fileService;
        private IRestrictionService restrictionService;
        private IGroupService groupService;

        public TransmittalController(IGroupService groupService, IRestrictionService restrictionService, ITransmittalService transmittalService, IUserService userService, 
            IFileService fileService)
        {
            this.restrictionService = restrictionService;
            this.transmittalService = transmittalService;
            this.userService = userService;
            this.fileService = fileService;
            this.groupService = groupService;
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
            var response = new JsonReply();

            response.ReplyingFor = "SendFile";

            if (Request.Files.Count < 1)
            {
                {
                    response.FailureReason = "<p>You must select a file to send.</p>";
                    response.Success = "false";
                    Response.StatusCode = successStatusCode;

                    return Json(response);
                }
            }

            if (String.IsNullOrWhiteSpace(model.recipientEmail) && String.IsNullOrWhiteSpace(model.recipientGroups))
            {
                response.FailureReason = "<p>You must fill out either an email address or a group to send to.</p>";
                response.Success = "false";
                Response.StatusCode = successStatusCode;

                return Json(response);
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

                response.FailureReason = errorTemp;
                response.Success="false";
                Response.StatusCode = successStatusCode;

                return Json(response);

            }

            //try
            //{
            

                    User thisUser = userService.GetUserByEmail(User.Identity.Name);

                    File file = new File();
                    file.FileData = new byte[Request.Files[0].ContentLength];
                    file.Name = Request.Files[0].FileName;
                    file.Size = Request.Files[0].ContentLength;
                    file.ContentType = Request.Files[0].ContentType;
                    file.DateCreated = DateTime.Now;
                    file.OwnerId = thisUser.UserId;

                    Request.Files[0].InputStream.Read(file.FileData, 0, Request.Files[0].ContentLength);
                    
                    var transmittal = new Transmittal{
                        SenderId = thisUser.UserId
                    };

                    transmittalService.CreateNewTransmittal(transmittal);
                    
                    #region AddRecipient
                    var r = model.recipientEmail.Trim();
                    User recipient;
                    try
                    {
                        recipient = userService.GetUserByEmail(r);
                    }
                    catch
                    {
                        recipient = new User
                        {
                            Email = r,
                            FirstName = "",
                            LastName = "",
                            PasswordHash = new Random().Next(1000, 9999).ToString(),
                            Verified = false,
                            VerifiedHash = new Random().Next(100000, 999999).ToString(),
                            RoleId = 1
                        };
                        userService.CreateUser(recipient);
                    }
                            
                    #endregion

                    transmittalService.AddRecipient(transmittal.TransmittalId, recipient.UserId);
                    transmittalService.AddFile(transmittal.TransmittalId, file);

                    #region UserRestrictions
                    if (!string.IsNullOrEmpty(model.emailRestriction))
                    {
                        List<int> userIds = new List<int>();
                        foreach (var email in model.emailRestriction.Split(';'))
                        {
                            var s = email.Trim().Replace(";", "");
                            User user;
                            try
                            {
                                user = userService.GetUserByEmail(s);
                            }
                            catch
                            {
                                user = new User
                                {
                                    Email = s,
                                    FirstName = "",
                                    LastName = "",
                                    PasswordHash = new Random().Next(1000, 9999).ToString(),
                                    Verified = false,
                                    VerifiedHash = new Random().Next(100000, 999999).ToString(),
                                    RoleId = 1
                                };

                                userService.CreateUser(user);
                            }
                            userIds.Add(user.UserId);

                        }
                        restrictionService.AddUserRestriction(file.FileId, userIds.ToArray());
                    }
                    #endregion
                    
                    #region GroupRestrictions
                    if (!string.IsNullOrEmpty(model.groupRestriction))
                    {
                        List<int> groupIds = new List<int>();
                        foreach (var group in model.groupRestriction.Split(';'))
                        {
                            var g = group.Trim().Replace(";", "");
                            var grp = groupService.GetGroupByName(g);
                            groupIds.Add(grp.GroupId);
                        }
                        restrictionService.AddGroupRestriction(file.FileId, groupIds.ToArray());
                    }
                    #endregion

                    #region TimeRangeRestrictions
                    if (model.timeIsEnabled.Contains("on"))
                    {
                        DateTime start = DateTime.Parse(model.startTimeDate);
                        start = new DateTime(start.Year, start.Month, start.Day, model.startTimeHour, model.startTimeMinute, 0);

                        DateTime end = DateTime.Parse(model.endTimeDate);
                        end = new DateTime(end.Year, end.Month, end.Day, model.endTimeHour, model.endTimeMinute, 0);

                        var timeRange = new TimeRange()
                        {
                            End = end,
                            Start = start,
                        };
                        restrictionService.AddTimeRangeRestriction(file.FileId, new TimeRange[] { timeRange });
                    }
                    #endregion

                    transmittalService.SendTransmittal(transmittal.TransmittalId);
                

            //}
            //catch
            //{
            //    response.FailureReason="<p>Something went wrong</p><p>Please confirm the details entered before attempting to submit again.</p>";
            //    response.Success = "false";
            //    Response.StatusCode = successStatusCode;

            //    return Json(response);
            //}

            response.Success = "true";
            response.GoTo = Url.Action("Index", "Home");

            Response.StatusCode = successStatusCode;
            return Json(response);

        }

        [Authorize]
        public ActionResult Download(int id)
        {
            try
            {
                if (fileService.UserCanAccessFile(id, userService.GetUserByEmail(User.Identity.Name).UserId, 4000, Request.UserHostAddress))
                {
                    var t = transmittalService.GetTransmittalById(id);
                    var f = fileService.GetFileById(t.Files.ToArray()[0].FileId);

                    return File(f.FileData, f.ContentType, f.Name);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

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
            transmittal.Sender = userService.GetUserByEmail(User.Identity.Name);
            transmittalService.CreateNewTransmittal(transmittal);
            return RedirectToAction("AddFile", new { id = transmittal.TransmittalId });
        }
        public ActionResult AddFile(int id)
        {
            return View(transmittalService.GetTransmittalById(id));
        }
        [HttpPost]
        public ActionResult AddFile(Transmittal transmittal, HttpPostedFileBase file)
        {
            var dfile = new File();
            dfile.Owner = userService.GetUserByEmail(User.Identity.Name);
            dfile.Revoked = false;
            dfile.Name = file.FileName;
            dfile.DateCreated = DateTime.Now;

            dfile.ContentType = file.ContentType;
            dfile.Size = file.ContentLength;
            dfile.FileData = new byte[file.ContentLength];

            file.InputStream.Read(dfile.FileData, 0, file.ContentLength);
            transmittalService.AddFile(transmittal.TransmittalId, dfile);

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
            transmittalService.SendTransmittal(id);
            return RedirectToAction("Index");
        }

    }
}
