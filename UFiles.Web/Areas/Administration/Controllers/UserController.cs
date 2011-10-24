using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        UFileContext db = new UFileContext();

        //
        // GET: /Administration/User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Administration/User/Details/5

        public ActionResult Details(int id)
        {
            return View(db.Users.Find(id));
        }

        //
        // GET: /Administration/User/Create

        public ActionResult Create()
        {
            ViewBag.PossibleRoles = db.Roles.ToList();
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
                 
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    //do nothing
                }
            }
            ViewBag.PossibleRoles = db.Roles.ToList();
            return View(user);
        }
        
        //
        // GET: /Administration/User/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.PossibleRoles = db.Roles.ToList();
            return View(db.Users.Find(id));
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
                    
                    db.Entry(user).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    //do nothing
                }
            }
            ViewBag.PossibleRoles = db.Roles.ToList();
            return View(user);
        }

        //
        // GET: /Administration/User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(db.Users.Find(id));
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
                    db.Users.Remove(user);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    //do nothing
                }
            }
            ViewBag.PossibleRoles = db.Roles.ToList();
            return View(user);
        }
    }
}
