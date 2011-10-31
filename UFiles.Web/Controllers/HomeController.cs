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
        private ITransmittalService transmittalService;

        public HomeController(IUserService userService, IFileService fileService, ITransmittalService transmittalService)
        {
            this.userService = userService;
            this.fileService = fileService;
            this.transmittalService = transmittalService;
        }
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Overview");
        }

        [Authorize]
        public ActionResult Overview()
        {
            OverviewModel overviewModel = new OverviewModel(userService, fileService, transmittalService, User.Identity.Name, Request.UserHostAddress);

            // End test data

            return View(overviewModel);
        }

        [Authorize]
        public ActionResult GetDetailedTransmittalInfo(int id)
        {
            var t = transmittalService.GetTransmittalById(id);
            var model = new TransmittalOverviewModel(t);
            return View(model);
        }
    }
}
