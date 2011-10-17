using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UFiles.Domain.Concrete;
using UFiles.Domain.Entities;

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
            db.Transmittals.Add(transmittal);
            db.SaveChanges();
            return transmittal.TransmittalId;
        }

        public void AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData)
        {
            var filedata = new FileData();
            filedata.Size = fileData.Length;
            filedata.Extension = fileType;
            var file = new File();
            file.Name = fileName;
            file.Owner = db.Users.Find(userId);
            file.Transmittals.Add(db.Transmittals.Find(transmittalId));
            db.Files.Add(file);
            db.FileDatas.Add(filedata);
            db.SaveChanges();

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
    }
}
