using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Concrete
{
    public class UFileContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileData> FileDatas { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<IPAddress> IPAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<TimeRange> TimeRanges { get; set; }
        public DbSet<Transmittal> Transmittals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UFileContext()
        {
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(user => user.ReceivedTransmittals).WithMany(transmittal => transmittal.Recipients);
            modelBuilder.Entity<Transmittal>().HasMany(transmittal => transmittal.Recipients).WithMany(user => user.ReceivedTransmittals);

            modelBuilder.Entity<User>().HasMany(user => user.OwnedGroups).WithRequired(group => group.Owner).WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasRequired(group => group.Owner).WithMany(user => user.OwnedGroups).WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().HasMany(user => user.MemberGroups).WithMany(group => group.Users);
            modelBuilder.Entity<Group>().HasMany(group => group.Users).WithMany(user => user.MemberGroups);

            base.OnModelCreating(modelBuilder);
        }
    }
}
