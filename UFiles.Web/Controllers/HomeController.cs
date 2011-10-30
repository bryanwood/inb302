using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using UFiles.Web.Models;
using UFiles.Domain.Concrete;

namespace UFiles.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private ITransmittalService transmittalService;
        public HomeController(IUserService userService, ITransmittalService transmittalService)
        {
            this.userService = userService;
            this.transmittalService = transmittalService;
        }
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Overview");
        }

        [Authorize]
        public ActionResult Overview()
        {
            OverviewModel overviewModel = new OverviewModel(userService, transmittalService, User.Identity.Name);

            // End test data

            return View(overviewModel);
        }

        [Authorize, HttpPost]
        public JsonResult GetDetailedTransmittalInfo(int transmittalID)
        {
            using (var context = new UFileContext())
            {
                Transmittal t = context.Transmittals
                    .Where(transmittal => transmittal.TransmittalId == transmittalID).Single();

                TransmittalOverviewModel model = new TransmittalOverviewModel(t);

                return Json(model);
            }

        }
    }
}
