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
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Overview");
        }

        [Authorize]
        public ActionResult Overview()
        {
            OverviewModel overviewModel = new OverviewModel(userService, User.Identity.Name);

            // Test data -- Delete after logging in works.
            TransmittalListingModel testTransmittal = new TransmittalListingModel();
            testTransmittal.FileName = "Test File.doc";
            testTransmittal.Email = "important.guy@example.com";
            testTransmittal.SentDate = DateTime.Now;
            testTransmittal.DownloadLink = "ABC";

            overviewModel.RecentlySentTransmittals.Add(testTransmittal);

            testTransmittal = new TransmittalListingModel();

            testTransmittal.FileName = "World Domination Plans.xls";
            testTransmittal.Email = "doctor.evil@example.com";
            testTransmittal.SentDate = DateTime.Now;
            testTransmittal.DownloadLink = "ABB";

            overviewModel.RecentlySentTransmittals.Add(testTransmittal);

            // End test data

            return View(overviewModel);
        }
    }
}
