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
    }
}
