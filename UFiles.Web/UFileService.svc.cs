using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;
using System.Data.Entity;

namespace UFiles.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UFileService" in code, svc and config file together.
    public class UFileService : IUFileService
    {
        UFileContext db = new UFileContext();

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
                    var existing = db.Users.Where(x => x.Email == recipient).Single();

                    db.Transmittals.Find(transmittalId).Recipients.Add(existing);
                }
                catch
                {
                    db.Transmittals.Find(transmittalId).Recipients.Add(new User
                    {
                        Email = recipient,
                        PasswordHash = new Random().Next(1000,9999).ToString(),
                        Verified  =false,
                        VerifiedHash = new Random().Next(100000,999999).ToString(),
                        Role = db.Roles.First()
                    });
                }
        }
            db.SaveChanges();
        }

        public void SendTransmittal(int transmittalId)
        {
            
        }


        public void AddUserRestriction(int fileId, string[] emails)
        {
            throw new NotImplementedException();
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
