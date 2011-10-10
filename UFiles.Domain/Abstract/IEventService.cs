using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IEventService
    {
        IQueryable<Event> GetEventsByUser(User user);
        IQueryable<Event> GetEventsByFile(File file);
        IQueryable<Event> GetEventsByTransmittal(Transmittal transmittal);
        Event GetEvent(int id);
        void AddFileAccessEvent(File file, User user);
        void AddTransmittalEvent(Transmittal transmittal);
        void AddUserEvent(User user);
    } 
}
