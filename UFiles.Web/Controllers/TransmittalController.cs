using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Web.Controllers
{
    public class TransmittalController : Controller
    {
        private ITransmittalService transmittalService;
        private IUserService userService;

        public TransmittalController(ITransmittalService transmittalService, IUserService userService)
        {
            this.transmittalService = transmittalService;
            this.userService = userService;
        }
        [Authorize]
        public ActionResult List()
        {
            var user = userService.GetUserByEmail(User.Identity.Name);
            var transmittals = transmittalService.GetTransmittalsByUser(user);

            return View(transmittals);
        }

        //
        // GET: /File/
        [Authorize]
        public ActionResult View(int id)
        {
            var user = userService.GetUserByEmail(User.Identity.Name);

            var transmittal = transmittalService.GetTransmittalById(id);

            //Check if the user is the sender or recipient
            if (transmittal.Recipients.Contains(user) || transmittal.Sender==user)
            {
                return View(transmittal);              
            }
            
            return RedirectToAction("Unavailable");
        }

        public ActionResult Unavailable()
        {
            return View();
        }
    }
}
