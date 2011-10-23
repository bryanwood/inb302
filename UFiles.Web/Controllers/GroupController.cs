using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Web.Models;

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

            if(String.IsNullOrWhiteSpace(deleteConfirmed))
            {
                return RedirectToAction("MyGroups");
            }

            Group g = groupService.GetGroup(groupID);
            User u = userService.GetUserByEmail(User.Identity.Name);

            if (g.Owner == null || g.Owner.UserId != u.UserId)
            {
                return RedirectToAction("MyGroups");
            }

            groupService.DeleteGroup(g);

            return RedirectToAction("MyGroups");

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

            Group newGroup = groupService.CreateGroup(userService.GetUserByEmail(User.Identity.Name));
            newGroup.Name = model.GroupName;

            foreach(string e in model.getEmailAddressList())
            {
                newGroup.Users.Add(userService.GetUserByEmail(e));
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
