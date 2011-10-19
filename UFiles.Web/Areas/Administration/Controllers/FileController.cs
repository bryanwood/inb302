using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class FileController : Controller
    {
        private UFileContext db = new UFileContext();

        //
        // GET: /Administration/File/

        public ActionResult Index()
        {

            return View(db.Files.ToList());
        }
        public ActionResult Delete(int id)
        {
            return View(db.Files.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(File file)
        {
            try
            {
                db.Files.Remove(file);
                db.SaveChanges();
            }
            catch { }

            return View(file);
        }
    }
}
