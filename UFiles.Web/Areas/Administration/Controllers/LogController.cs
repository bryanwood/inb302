using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using System.Data.Entity;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class LogController : Controller
    {
        private UFileContext db = new UFileContext();
        //
        // GET: /Administration/Log/

        public ActionResult Users()
        {
            //TODO: Include
            return View(db.Events.OfType<UserEvent>().Include(x=>x.User).ToList());
        }
        public ActionResult Transmittals()
        {
            return View(db.Events.OfType<TransmittalEvent>().Include(x=>x.Transmittal).Include("Transmittal.Sender").ToList());
        }
        public ActionResult Files()
        {
            return View(db.Events.OfType<FileAccessEvent>().Include(x=>x.File).Include(x=>x.User).ToList());
        }

    }
}
