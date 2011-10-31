using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UFiles.Domain.Entities;
using System.Data.Entity.Infrastructure;

namespace UFiles.Domain.Abstract
{
    public interface IUFileContext
    {
        IDbSet<Event> Events { get; set; }
        IDbSet<File> Files { get; set; }
        IDbSet<Group> Groups { get; set; }
        IDbSet<IPAddress> IPAddresses { get; set; }
        IDbSet<Location> Locations { get; set; }
        IDbSet<Restriction> Restrictions { get; set; }
        IDbSet<TimeRange> TimeRanges { get; set; }
        IDbSet<Transmittal> Transmittals { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<Role> Roles { get; set; }

        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
