using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone_Website_Interface_Prototype.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return RedirectToAction("Download");
        }

        public ActionResult Download()
        {
            return View();
        }

    }
}
