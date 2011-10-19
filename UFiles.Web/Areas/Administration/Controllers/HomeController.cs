using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        private UFileContext db = new UFileContext();
        //
        // GET: /Administration/Home/

        public ActionResult Index()
        {
            var vm = new AdminDashboard
            {
                Files = db.Files.Count(),
                TotalStorageSize = db.Files.Sum(x=>x.Size),
                RegisteredUsers = db.Users.Count(),
                TransmittalsSent = db.Transmittals.Where(x=>x.Sent).Count()
                   
            };
            return View(vm);
        }
        public class AdminDashboard
        {
            public double TotalStorageSize { get; set; }
            public int RegisteredUsers { get; set; }
            public int TransmittalsSent { get; set; }
            public int Files { get; set; }

        }

    }
}
