using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface ITransmittalService
    {
        IQueryable<Transmittal> GetTransmittalsBySender(User user);
        IQueryable<Transmittal> GetTransmittalsByRecipient(User user);
        Transmittal GetTransmittalById(int id);
        void CreateNewTransmittal(Transmittal t);
        void AddRecipient(int id, int recipientId);
        void SendTransmittal(int id);
        void AddFile(int transmittalId, File file);
    }
}
