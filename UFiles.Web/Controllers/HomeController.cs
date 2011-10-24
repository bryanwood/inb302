using System;
using System.Web.Mvc;
using UFiles.Domain.Abstract;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using UFiles.Web.Models;
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
    }
}
