﻿using System;
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
        private IEventService eventService;
        private IEmailService emailService;
        public TransmittalService(IUFileContext context, IEventService eventService, IEmailService emailService)
        {
            db = context;
            this.eventService = eventService;
            this.emailService = emailService;
        }

        public void CreateNewTransmittal(Transmittal t)
        {
            db.Transmittals.Add(t);
            db.SaveChanges();
            eventService.AddTransmittalEvent(t);
        }

        public IQueryable<Transmittal> GetTransmittalsBySender(int userId)
        {
            return db.Transmittals.Include(x => x.Sender).Include(x => x.Recipients).Include(x => x.Files).Include("Files.Restrictions").Where(t => t.Sender.UserId == userId);
        }

        public IQueryable<Transmittal> GetTransmittalsByRecipient(int userId)
        {
            return db.Transmittals.Include(x => x.Files).Include(x => x.Sender).Include(x => x.Recipients).Include("Files.Restrictions").Where(t => t.Recipients.Any(x => x.UserId == userId));
        }

        public Transmittal GetTransmittalById(int id)
        {
            var tr = db.Transmittals.Include(f => f.Files).Include(x => x.Recipients).Include(x => x.Sender).Include("Files.Restrictions").Where(t => t.TransmittalId == id).Single();
            eventService.AddTransmittalEvent(tr);
            return tr;
        }

        public void AddRecipient(int id, int recipientId)
        {
            var trans = db.Transmittals.Include(x=>x.Recipients).Where(t => t.TransmittalId == id).Single();
            
            var user = db.Users.Where(u => u.UserId == recipientId).Single();

            trans.Recipients.Add(user);
            db.SaveChanges();
            eventService.AddTransmittalEvent(trans);
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
            eventService.AddTransmittalEvent(transmittal);
        }

        public void SendTransmittal(int id)
        {
            var trans = db.Transmittals.Include(x=>x.Recipients).Where(t=>t.TransmittalId==id).Single();
            trans.Sent = true;
            db.SaveChanges();
            eventService.AddTransmittalEvent(trans);
            List<string> rs = new List<string>();
            foreach (var r in trans.Recipients)
            {
                rs.Add(r.Email);
            }
            emailService.SendEmail(rs.ToArray(), "Message from uFiles");
        }

      
    }
}
