using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string VerifiedHash { get; set; }
        public bool Verified { get; set; }

        public virtual ICollection<Group> MemberGroups { get; set; }
        public virtual ICollection<Group> OwnedGroups { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FileAccessEvent> FileAccessEvents { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
        public virtual ICollection<UserRestriction> UserRestrictions { get; set; }
        public virtual ICollection<Transmittal> ReceivedTransmittals { get; set; }
        public virtual ICollection<Transmittal> SentTransmittals { get; set; }
    }
}
