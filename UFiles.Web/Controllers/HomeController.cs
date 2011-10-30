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
        private IFileService fileService;
        public HomeController(IUserService userService, IFileService fileService)
        {
            this.userService = userService;
            this.fileService = fileService;
        }
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Overview");
        }

        [Authorize]
        public ActionResult Overview()
        {
            OverviewModel overviewModel = new OverviewModel(userService, fileService, User.Identity.Name, Request.UserHostAddress);

            // End test data

            return View(overviewModel);
        }

        [Authorize, HttpPost]
        public ActionResult GetDetailedTransmittalInfo(int id)
        {
            using (var context = new UFileContext())
            {
                Transmittal t = context.Transmittals
                    .Where(transmittal => transmittal.TransmittalId == id).Single();

                t.Files = (from transmittal in context.Transmittals
                           where transmittal.TransmittalId == t.TransmittalId
                           select transmittal.Files).First();

                IEnumerable<ICollection<Restriction>> r = (from transmittal in context.Transmittals
                                                           where transmittal.TransmittalId == t.TransmittalId
                                                           select transmittal.Files.FirstOrDefault().Restrictions);

                t.Files.ToArray()[0].Restrictions = r.ToArray()[0];
                t.Sender = (from transmittal in context.Transmittals
                            where transmittal.TransmittalId == t.TransmittalId
                            select transmittal.Sender).First();

                 var model = new TransmittalOverviewModel(t);

                return View(model);
            }

        }
    }
}
