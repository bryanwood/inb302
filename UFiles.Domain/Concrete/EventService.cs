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

        private IUnitOfWork unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            return unitOfWork.EventRepository.Where(e => e.EventId == id).Single();
        }

        public void AddFileAccessEvent(Entities.File file, Entities.User user)
        {
            throw new NotImplementedException();
        }

        public void AddTransmittalEvent(Entities.Transmittal transmittal)
        {
            throw new NotImplementedException();
        }

        public void AddUserEvent(Entities.User user)
        {
            throw new NotImplementedException();
        }
    }
}
