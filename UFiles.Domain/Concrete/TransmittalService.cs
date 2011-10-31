using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;
using System.Data.Entity;

namespace UFiles.Domain.Concrete
{
    public class TransmittalService : ITransmittalService
    {
        private IUFileContext db;

        public TransmittalService(IUFileContext context)
        {
            db = context;
        }

        public void CreateNewTransmittal(Transmittal t)
        {
            db.Transmittals.Add(t);
            db.SaveChanges();
        }

        public IQueryable<Transmittal> GetTransmittalsBySender(User user)
        {
            return db.Transmittals.Where(t => t.Sender.UserId == user.UserId);
        }

        public IQueryable<Transmittal> GetTransmittalsByRecipient(User user)
        {
            return db.Transmittals.Where(t => t.Recipients.Contains(user));
        }

        public Transmittal GetTransmittalById(int id)
        {
            return db.Transmittals.Include(f=>f.Files).Where(t => t.TransmittalId == id).Single();
        }

        public void AddRecipient(int id, int recipientId)
        {
            var trans = db.Transmittals.Include(x=>x.Recipients).Where(t => t.TransmittalId == id).Single();
            
            var user = db.Users.Where(u => u.UserId == recipientId).Single();

            trans.Recipients.Add(user);
            db.SaveChanges();
        }

        public Transmittal AddRestriction(Transmittal transmittal, Restriction restriction)
        {
            throw new NotImplementedException();
        }

        public void AddFile(int transmittalId, File file)
        {
            var transmittal = db.Transmittals.Include(x => x.Files).Where(x => x.TransmittalId == transmittalId).Single();
            transmittal.Files.Add(file);
            db.SaveChanges();
        }

        public void SendTransmittal(int id)
        {
            var trans = db.Transmittals.Find(id);
            trans.Sent = true;
            db.SaveChanges();
        }

      
    }
}
