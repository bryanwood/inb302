using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFiles.Web.Controllers
{
    public class CallbackController : Controller
    {
        //
        // GET: /Callback/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDetailedTransmittalInfo(int transmittalID)
        {
            Dictionary<string, string> jsonDictionary = new Dictionary<string, string>();

            return Json(jsonDictionary);

        }
    }
}
