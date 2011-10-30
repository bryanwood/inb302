using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using System.Data.Entity;
using UFiles.Domain.Abstract;
using System.ServiceModel.Activation;

namespace UFiles.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UFileService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class UFileService : IUFileService
    {
        UFileContext db = new UFileContext();
        private IEmailService emailService;
        private IUserService userService;
        private ITransmittalService transmittalService;
        private IFileService fileService;
       
        public UFileService(IEmailService emailService, IUserService userService, ITransmittalService transmittalService, IFileService fileService)
        {
            this.emailService = emailService;
            this.userService = userService;
            this.transmittalService = transmittalService;
            this.fileService = fileService;
        }
        public int Login(string email, string password)
        {
            return db.Users.Where(x => x.Email == email && x.PasswordHash == password).Single().UserId;
        }

        public int NewTransmittal(int userId)
        {
            var transmittal = new Transmittal();
            transmittal.SenderId = userId;
            db.Transmittals.Add(transmittal);
            db.SaveChanges();
            return transmittal.TransmittalId;
        }
        public Location[] GetLocations()
        {
            return db.Locations.ToArray();
        }
        public Group[] GetGroups(int userId)
        {
            return db.Groups.ToArray();
        }
    


        public int AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData)
        {
           
            var file = new File();
            file.Name = fileName;
            file.OwnerId = userId;
            file.DateCreated = DateTime.Now;
            file.ContentType = fileType;
            file.FileData = fileData;
            file.Size = fileData.Length;
            //file.Transmittals.Add(db.Transmittals.Find(transmittalId));
            var transmittal = db.Transmittals.Include(x=>x.Files).Where(s=>s.TransmittalId==transmittalId).Single();
            transmittal.Files.Add(file);
//            db.Files.Add(file);
                      db.SaveChanges();
                      return file.FileId;

        }

        public void AddRecipients(int transmittalId, string[] recipients)
        {
            foreach(var recipient in recipients){
                try
                {
                    var existing = userService.GetUserByEmail(recipient);
                    transmittalService.AddRecipient(transmittalId, existing.UserId);
                }
                catch
                {
                    var user = new User
                    {
                        Email = recipient,
                        FirstName = "",
                        LastName = "",
                        PasswordHash = new Random().Next(1000, 9999).ToString(),
                        Verified = false,
                        VerifiedHash = new Random().Next(100000, 999999).ToString(),
                        RoleId = db.Roles.First().RoleId
                    };

                    var u = userService.CreateUser(user);
                    transmittalService.AddRecipient(transmittalId, u.UserId);
                }
            }
        }

        public void SendTransmittal(int transmittalId)
        {
            transmittalService.SendTransmittal(transmittalId);
        }


        public void AddUserRestriction(int fileId, string[] emails)
        {
            
        }

        public void AddIPRestriction(int fileId, string[] IPs)
        {
            throw new NotImplementedException();
        }

        public void AddGroupRestruction(int fileId, int[] groupIds)
        {
            throw new NotImplementedException();
        }

        public void AddLocationRestriction(int fileId, string[] postCodes)
        {
            throw new NotImplementedException();
        }
    }
}
