using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Abstract;
using System.Data.Entity;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public IRepository<Event> EventRepository { get; private set; }
        public IRepository<File> FileRepository { get; private set; }
       
        public IRepository<Group> GroupRepository { get; private set; }
        public IRepository<IPAddress> IPAddressRepository { get; private set; }
        public IRepository<Location> LocationRepository { get; private set; }
        public IRepository<Restriction> RestrictionRepository { get; private set; }
        public IRepository<Role> RoleRepository { get; private set; }
        public IRepository<TimeRange> TimeRangeRepository { get; private set; }
        public IRepository<Transmittal> TransmittalRepository { get; private set; }
        public IRepository<User> UserRepository { get; private set; }

        public UnitOfWork(
            IRepository<Event> eventRepository, 
            IRepository<File> fileRepository, 
       
            IRepository<Group> groupRepository, 
            IRepository<IPAddress> iPAddressRepository, 
            IRepository<Location> locationRepository, 
            IRepository<Restriction> restrictionRepository, 
            IRepository<Role> roleRepository, 
            IRepository<TimeRange> timeRangeRepository, 
            IRepository<Transmittal> transmittalRepository, 
            IRepository<User> userRepository)
        {
            context = new UFileContext();
            this.EventRepository = eventRepository;
          
            this.FileRepository = fileRepository;
            this.GroupRepository = groupRepository;
            this.IPAddressRepository = iPAddressRepository;
            this.LocationRepository = locationRepository;
            this.RestrictionRepository = restrictionRepository;
            this.RoleRepository = roleRepository;
            this.TimeRangeRepository = timeRangeRepository;
            this.UserRepository = userRepository;
        }

        

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
