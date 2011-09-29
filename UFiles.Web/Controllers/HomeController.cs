using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Entities;
namespace UFiles.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
           
            return View();
        }

        public ActionResult Overview()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
