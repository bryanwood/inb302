using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;

namespace UFiles.Web.Controllers
{
    public class FileController : Controller
    {
        private UFileContext db = new UFileContext();
        public FileResult Download(int id)
        {
            //TODO: Check Restrictions
            var file = db.Files.Find(id);
            return File(file.FileData, file.ContentType);
        }
        public ActionResult View(int id)
        {
            //TODO: Check restrictions
            return View(db.Files.Find(id));
        }
        public ActionResult Delete(int id)
        {
            //TODO: check owner
            return View(db.Files.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(File file)
        {
            //TODO: check owner
            db.Files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("Index", "Transmittal");
        }

        [HttpPost]
        public ActionResult Revoke(int id)
        {
            //TODO: Check for owner 
            var file = db.Files.Find(id);
            file.Revoked = true;
            db.SaveChanges();

            return RedirectToAction("View", new { id = id });
        }

    }
}
