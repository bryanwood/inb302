using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class TransmittalService : ITransmittalService
    {
        private UFileContext db;

        public TransmittalService(UFileContext context)
        {
            db = context;
        }

        public void CreateNewTransmittal(Transmittal t)
        {

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
            return db.Transmittals.Where(t => t.TransmittalId == id).Single();
        }

        public void AddRecipient(int id, int recipientId)
        {
            var trans = db.Transmittals.Where(t => t.TransmittalId == id).Single();
            
            var user = db.Users.Where(u => u.UserId == recipientId).Single();

            trans.Recipients.Add(user);
            db.SaveChanges();
        }

        public Transmittal AddRestriction(Transmittal transmittal, Restriction restriction)
        {
            throw new NotImplementedException();
        }

      
    }
}
