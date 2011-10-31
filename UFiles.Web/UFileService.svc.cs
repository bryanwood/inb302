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
        private IEmailService emailService;
        private IUserService userService;
        private ITransmittalService transmittalService;
        private IFileService fileService;
        private IRestrictionService restrictionService;
        private IGroupService groupService;
        public UFileService(IGroupService groupService, IRestrictionService restrictionService, IEmailService emailService, IUserService userService, ITransmittalService transmittalService, IFileService fileService)
        {
            this.groupService = groupService;
            this.emailService = emailService;
            this.userService = userService;
            this.transmittalService = transmittalService;
            this.fileService = fileService;
            this.restrictionService = restrictionService;
        }
        public int Login(string email, string password)
        {
            var user = userService.GetUserByEmail(email);
            if (user.PasswordHash == password)
            {
                return user.UserId;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public int NewTransmittal(int userId)
        {
            var transmittal = new Transmittal();
            transmittal.SenderId = userId;
            transmittalService.CreateNewTransmittal(transmittal);
            return transmittal.TransmittalId;
        }

        public Group[] GetGroups(int userId)
        {
            return groupService.GetGroupsByOwner(userService.GetUserById(userId)).ToArray(); 
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
            transmittalService.AddFile(transmittalId, file);
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
                        RoleId = 1
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
            List<int> UserIds = new List<int>();
             foreach(var recipient in emails){
                 User user;
                try
                {
                    user = userService.GetUserByEmail(recipient);
                }
                catch
                {
                    user = new User
                    {
                        Email = recipient,
                        FirstName = "",
                        LastName = "",
                        PasswordHash = new Random().Next(1000, 9999).ToString(),
                        Verified = false,
                        VerifiedHash = new Random().Next(100000, 999999).ToString(),
                        RoleId = 1
                    };

                    user = userService.CreateUser(user);
                }
                 UserIds.Add(user.UserId);
            }

            restrictionService.AddUserRestriction(fileId, UserIds.ToArray() );
        }

        public void AddIPRestriction(int fileId, string[] IPs)
        {
            restrictionService.AddIPRestriction(fileId, IPs);
        }

        public void AddGroupRestriction(int fileId, int[] groupIds)
        {
            restrictionService.AddGroupRestriction(fileId, groupIds);
        }

        public void AddTimeRangeRestriction(int fileId, TimeRange[] timeRanges)
        {
            restrictionService.AddTimeRangeRestriction(fileId, timeRanges);
        }

        public void AddLocationRestriction(int fileId, string[] postCodes)
        {
            throw new NotImplementedException();
        }
    }
}
