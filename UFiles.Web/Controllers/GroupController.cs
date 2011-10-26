using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Web.Models;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Controllers
{
    public class GroupController : Controller
    {
        private IGroupService groupService;
        private IUserService userService;

        public GroupController(IGroupService groupService, IUserService userService)
        {
            this.groupService = groupService;
            this.userService = userService;
        }
        //
        // GET: /Group/

        [Authorize]
        public ActionResult Index()
        {
            return RedirectToActionPermanent("MyGroups");
        }

        [Authorize]
        public ActionResult MyGroups()
        {
            GroupViewModel model = new GroupViewModel(userService, groupService, User.Identity.Name);

            return View(model);
        }

        [Authorize]
        public ActionResult GetDetail(int groupID)
        {
            GroupDetailModel model = new GroupDetailModel(groupID, groupService, userService,
                User.Identity.Name);

            return View(model);

        }

        [Authorize]
        public ActionResult CheckDelete(int groupID)
        {

            GroupDetailModel model = new GroupDetailModel(groupID, groupService, userService,
                User.Identity.Name);

            return View(model);

        }

        [Authorize, HttpPost]
        public ActionResult DeleteGroup(int groupID, string deleteConfirmed)
        {

            if (String.IsNullOrWhiteSpace(deleteConfirmed))
            {
                return RedirectToAction("MyGroups");
            }

            using (var context = new UFileContext())
            {
                try
                {
                    Group g = context.Groups.Where(group => group.GroupId == groupID).Single();
                    User u = context.Users.Where(user => user.Email == User.Identity.Name).Single();

                    if (g.Owner == null || g.Owner.UserId != u.UserId)
                    {
                        return RedirectToAction("MyGroups");
                    }

                    context.Groups.Remove(g);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    return RedirectToAction("MyGroups");
                }

                return RedirectToAction("MyGroups");

            }

        }

        [Authorize, HttpPost]
        public JsonResult EditGroup(EditGroupModel model)
        {
            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

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
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;
            }
            using (var context = new UFileContext())
            {

                Group thisGroup = context.Groups.Where(g => g.GroupId == model.GroupID).Single();
                thisGroup.Users = (from g in context.Groups
                                   where g.GroupId == thisGroup.GroupId
                                   select g.Users).Single();

                foreach (User u in thisGroup.Users)
                {
                    foreach (string e in model.EmailAddressList)
                    {
                        if (String.Equals(e, u.Email, StringComparison.CurrentCultureIgnoreCase))
                        {
                            break;
                        }
                        thisGroup.Users.Remove(u);
                        model.EmailAddressList.Remove(e);
                    }
                }

                foreach (string e in model.EmailAddressList)
                {
                    try
                    {
                        thisGroup.Users.Add(context.Users.Where<User>(u => u.Email == e).Single());
                    }
                    catch (Exception ex)
                    {
                        jsonDictionary.Add("FailureReason", "<p>There is no registered user with " +
                        "the email address of: " + e + "</p>");
                        Response.StatusCode = errorStatusCode;

                        jsonReply = Json(jsonDictionary);

                        return jsonReply;
                    }
                }
                context.Entry(thisGroup).State = System.Data.EntityState.Modified;
                context.SaveChanges();

            }

            Response.StatusCode = successStatusCode;
            jsonDictionary.Add("GoTo", Url.Action("MyGroups"));

            return Json(jsonDictionary);
        }

        [Authorize, HttpPost]
        public JsonResult CreateGroup(CreateGroupModel model)
        {

            const int errorStatusCode = 400;
            const int successStatusCode = 201;

            JsonResult jsonReply = new JsonResult();
            Dictionary<String, String> jsonDictionary = new Dictionary<string, string>();

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
                Response.StatusCode = errorStatusCode;

                jsonReply = Json(jsonDictionary);

                return jsonReply;

            }

            using (var context = new UFileContext())
            {

                Group newGroup = new Group();

                newGroup.Name = model.GroupName;
                newGroup.Owner = context.Users.Where<User>(u => u.Email == User.Identity.Name).Single();
                newGroup.Users = new List<User>();

                foreach (string e in model.EmailAddressList)
                {
                    try
                    {
                        newGroup.Users.Add(context.Users.Where<User>(u => u.Email == e).Single());
                    }
                    catch (Exception ex)
                    {
                        jsonDictionary.Add("FailureReason", "<p>There is no registered user with " +
                        "the email address of: " + e + "</p>");
                        Response.StatusCode = errorStatusCode;

                        jsonReply = Json(jsonDictionary);

                        return jsonReply;
                    }
                }

                context.Groups.Add(newGroup);
                context.SaveChanges();

            }

            Response.StatusCode = successStatusCode;
            jsonDictionary.Add("GoTo", Url.Action("MyGroups"));

            return Json(jsonDictionary);

        }

        //
        // GET: /Group/Details/5

        public ActionResult Details(int id)
        {
            var group = groupService.GetGroup(id);
            return View(group);
        }

        //
        // GET: /Group/Create

        public ActionResult Create()
        {
            return View(new Group());
        }

        //
        // POST: /Group/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here - COMPLEX VIEW

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Group/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here - COMPLEX VIEW

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Group/Delete/5

        public ActionResult Delete(int id)
        {
            var group = groupService.GetGroup(id);
            return View(group);
        }

        //
        // POST: /Group/Delete/5

        [HttpPost]
        public ActionResult Delete(Group group)
        {
            try
            {

                groupService.DeleteGroup(group);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
