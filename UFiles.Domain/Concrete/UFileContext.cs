using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UFiles.Domain.Entities;
using UFiles.Domain.Abstract;

namespace UFiles.Domain.Concrete
{
    public class UFileContext : DbContext, IUFileContext
    {
        public IDbSet<Event> Events { get; set; }
        public IDbSet<File> Files { get; set; }
        public IDbSet<Group> Groups { get; set; }
        public IDbSet<IPAddress> IPAddresses { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Restriction> Restrictions { get; set; }
        public IDbSet<TimeRange> TimeRanges { get; set; }
        public IDbSet<Transmittal> Transmittals { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public UFileContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<FileAccessEvent>().HasRequired(x => x.File).WithMany(x => x.FileAccessEvents).HasForeignKey(x=>x.FileId).WillCascadeOnDelete(false);
            modelBuilder.Entity<FileAccessEvent>().HasRequired(x => x.User).WithMany(x => x.FileAccessEvents).HasForeignKey(x=>x.UserId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Transmittal>().HasRequired(x => x.Sender).WithMany(x => x.SentTransmittals).HasForeignKey(x => x.SenderId).WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>().HasMany(user => user.ReceivedTransmittals).WithMany(transmittal => transmittal.Recipients);
            //modelBuilder.Entity<Transmittal>().HasMany(transmittal => transmittal.Recipients).WithMany(user => user.ReceivedTransmittals);

            //modelBuilder.Entity<User>().HasMany(user => user.OwnedGroups).WithRequired(group => group.Owner).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Group>().HasRequired(group => group.Owner).WithMany(user => user.OwnedGroups).WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>().HasMany(user => user.MemberGroups).WithMany(group => group.Users);
            //modelBuilder.Entity<Group>().HasMany(group => group.Users).WithMany(user => user.MemberGroups);
            
            base.OnModelCreating(modelBuilder);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
