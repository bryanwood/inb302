using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IEventService
    {
        /// <summary>
        /// Returns a list of events for the specified user
        /// </summary>
        /// <param name="user">the user object to get events for</param>
        /// <returns>list of events</returns>
        IQueryable<Event> GetEventsByUser(User user);
        
        /// <summary>
        /// Returns a list of events for the specified file
        /// </summary>
        /// <param name="file">the file to get events for</param>
        /// <returns>list of events</returns>
        IQueryable<Event> GetEventsByFile(File file);

        /// <summary>
        /// Returns a list of events for the specified transmittal
        /// </summary>
        /// <param name="transmittal">the transmittal object to get events for</param>
        /// <returns>list of events</returns>
        IQueryable<Event> GetEventsByTransmittal(Transmittal transmittal);

        /// <summary>
        /// Gets a specific event by its id
        /// </summary>
        /// <param name="id">id of the event to get</param>
        /// <returns>an event</returns>
        Event GetEvent(int id);

        /// <summary>
        /// Adds a new file access event to the event log
        /// </summary>
        /// <param name="file">the file involved in the event</param>
        /// <param name="user">the user involved in the event</param>
        void AddFileAccessEvent(File file, User user);

        /// <summary>
        /// Adds a new transmittal event to the event log
        /// </summary>
        /// <param name="transmittal">the transmittal to add the event for</param>
        void AddTransmittalEvent(Transmittal transmittal);

        /// <summary>
        /// Adds a new user event to the event log
        /// </summary>
        /// <param name="user">the user to add the event for</param>
        void AddUserEvent(User user);
    } 
}
