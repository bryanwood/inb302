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

        public ActionResult Index()
        {
            var user = userService.GetUserByEmail(User.Identity.Name);

            var groups = groupService.GetGroupsByOwner(user);

            return View(groups);
        }

        public ActionResult MyGroups()
        {
            GroupViewModel model = new GroupViewModel(userService, groupService, User.Identity.Name);

            return View(model);
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
