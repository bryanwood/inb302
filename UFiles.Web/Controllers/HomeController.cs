using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Web.Kits.Authentication;

namespace UFiles.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private AuthKit authKit;

        public HomeController()
        {
            authKit = new AuthKit(this);
        }

        public ActionResult Index()
        {
            return authKit.DirectView(View(), AuthKit.ViewAuthRequirement.AUTH_LOGGED_IN);
        }

    }
}
