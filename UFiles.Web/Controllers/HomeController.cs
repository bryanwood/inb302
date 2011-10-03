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
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
           
            return View();
        }

        public ActionResult Overview()
        {
            OverviewModel overviewModel = new OverviewModel();
            IUserService userService = new UserService();

            User currentUser = userService.GetUserByEmail(User.Identity.Name);

            overviewModel.LoggedInUser.FName = currentUser.FirstName;
            overviewModel.LoggedInUser.LName = currentUser.LastName;
            overviewModel.LoggedInUser.Email = currentUser.Email;

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

        public ActionResult About()
        {
            return View();
        }
    }
}
