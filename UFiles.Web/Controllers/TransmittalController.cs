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
        private IRepository<File> _fileRepo;
        private IRepository<User> _userRepo;
        private IRepository<Transmittal> _transmittalRepo;

        private IUnitOfWork _unitOfWork;

        public TransmittalController(IUnitOfWork unitOfWork, IRepository<File> fileRepository, IRepository<User> userRepository, IRepository<Transmittal> transmittalRepository)
        {
            _unitOfWork = unitOfWork;

            _fileRepo = fileRepository;
            _userRepo = userRepository;
            _transmittalRepo = transmittalRepository;

            _fileRepo.UnitOfWork = _unitOfWork;
            _userRepo.UnitOfWork = _unitOfWork;
            _transmittalRepo.UnitOfWork = _unitOfWork;
        }
        [Authorize]
        public ActionResult List()
        {

            var transmittals = _transmittalRepo.All().Include(t=>t.Files).Where(t=>t.Sender.Email == User.Identity.Name);

            return View(transmittals);
        }

        //
        // GET: /File/
        [Authorize]
        public ActionResult View(int id)
        {
            var user = _userRepo.All().Where(u => u.Email == User.Identity.Name).Single();

            var transmittal = _transmittalRepo.All().Where(t=>t.TransmittalId==id).Include(u=>u.Files).Include(u=>u.Files.Select(f=>f.FileData)).Single();

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
