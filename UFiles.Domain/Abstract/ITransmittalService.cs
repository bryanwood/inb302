using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface ITransmittalService
    {
        IQueryable<Transmittal> GetTransmittalsByUser(User user);
        Transmittal GetTransmittalById(int id);
       // Transmittal CreateNewTransmittal();
        //Transmittal AddRestriction(Transmittal transmittal, Restriction restriction);
        //Transmittal AddFile(int transmittalId, File file);
    }
}
