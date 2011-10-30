using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface ITransmittalService
    {
        /// <summary>
        /// Gets all the transmittals sent by the user
        /// </summary>
        /// <param name="user">the user</param>
        /// <returns>list of transmittal</returns>
        IQueryable<Transmittal> GetTransmittalsBySender(User user);

        /// <summary>
        /// gets all the transmittals recieved by the user
        /// </summary>
        /// <param name="user">the user</param>
        /// <returns>list of transmittal</returns>
        IQueryable<Transmittal> GetTransmittalsByRecipient(User user);

        /// <summary>
        /// get a specific transmittal by its id
        /// </summary>
        /// <param name="id">id of the transmittal</param>
        /// <returns>a transmittal</returns>
        Transmittal GetTransmittalById(int id);

        /// <summary>
        /// create a new transmittal
        /// </summary>
        /// <param name="t">the transmittal to create</param>
        void CreateNewTransmittal(Transmittal t);

        /// <summary>
        /// adds a user to the transmittal as a recipient
        /// </summary>
        /// <param name="id">id of the transmittal</param>
        /// <param name="recipientId">id of the user</param>
        void AddRecipient(int id, int recipientId);

        /// <summary>
        /// sends a transmittal making it available to recipients
        /// </summary>
        /// <param name="id">id of the transmittal</param>
        void SendTransmittal(int id);

        /// <summary>
        /// adds a file to a transmittal
        /// </summary>
        /// <param name="transmittalId">id of the transmittal</param>
        /// <param name="file">the file to add</param>
        void AddFile(int transmittalId, File file);
    }
}
