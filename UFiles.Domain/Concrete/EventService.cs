﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class EventService : IEventService
    
    {

        private IUFileContext db;

        public EventService(IUFileContext context)
        {
            db = context;
           
        }

        public IQueryable<Entities.Event> GetEventsByUser(Entities.User user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Event> GetEventsByFile(Entities.File file)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Event> GetEventsByTransmittal(Entities.Transmittal transmittal)
        {
            throw new NotImplementedException();
        }

        public Entities.Event GetEvent(int id)
        {
            return db.Events.Where(e => e.EventId == id).Single();
        }

        public void AddFileAccessEvent(Entities.File file, Entities.User user)
        {
            db.Events.Add(new FileAccessEvent
            {
                FileId = file.FileId,
                UserId = user.UserId,
                Occurred = DateTime.Now
            });
            db.SaveChanges();
        }

        public void AddTransmittalEvent(Entities.Transmittal transmittal)
        {
            db.Events.Add(new TransmittalEvent
            {
                TransmittalId = transmittal.TransmittalId,
                Occurred = DateTime.Now
            });
            db.SaveChanges();
        }

        public void AddUserEvent(Entities.User user)
        {
            db.Events.Add(new UserEvent
            {
                Occurred = DateTime.Now,
                UserId = user.UserId
            });
            db.SaveChanges();
        }
    }
}
