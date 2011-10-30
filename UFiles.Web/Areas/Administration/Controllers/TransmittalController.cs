using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;

namespace UFiles.Web.Areas.Administration.Controllers
{
    public class TransmittalController : Controller
    {
        private UFileContext db = new UFileContext();
        //
        // GET: /Administration/Transmittal/

        public ActionResult Index()
        {
            return View(db.Transmittals.Include(x=>x.Sender).Include(x=>x.Recipients).ToList());
        }

        public ActionResult Edit(int id)
        {
            return View(db.Transmittals.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Transmittal transmittal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(transmittal).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                catch { }

            }
            return View(transmittal);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Transmittals.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(Transmittal transmittal)
        {
            try
            {
                db.Transmittals.Remove(transmittal);
                db.SaveChanges();
            }
            catch
            {

            }
            return View(transmittal);
        }
    }
}
