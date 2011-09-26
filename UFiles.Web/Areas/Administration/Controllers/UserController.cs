using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //
        // GET: /Administration/User/

        public ActionResult Index()
        {
            return View(userService.GetAllUsers());
        }

        //
        // GET: /Administration/User/Details/5

        public ActionResult Details(int id)
        {
            return View(userService.GetUserById(id));
        }

        //
        // GET: /Administration/User/Create

        public ActionResult Create()
        {
            return View(new User());
        } 

        //
        // POST: /Administration/User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    userService.CreateUser(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        
        //
        // GET: /Administration/User/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(userService.GetUserById(id));
        }

        //
        // POST: /Administration/User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    userService.SaveUser(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        //
        // GET: /Administration/User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(userService.GetUserById(id));
        }

        //
        // POST: /Administration/User/Delete/5

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
    }
}
