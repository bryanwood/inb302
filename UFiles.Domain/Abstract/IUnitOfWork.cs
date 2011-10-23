using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Event>          EventRepository { get; }
        IRepository<File>           FileRepository { get;  }
        IRepository<Group>          GroupRepository { get;  }
        IRepository<IPAddress>      IPAddressRepository { get; }
        IRepository<Location>       LocationRepository { get; }
        IRepository<Restriction>    RestrictionRepository { get;  }
        IRepository<Role>           RoleRepository { get;  }
        IRepository<TimeRange>      TimeRangeRepository { get; }
        IRepository<Transmittal>    TransmittalRepository { get; }
        IRepository<User>           UserRepository { get; }

        void Save();
    }
}
