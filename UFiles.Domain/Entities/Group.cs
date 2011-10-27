using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
      
        public User Owner { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GroupRestriction> GroupRestrictions { get; set; }
    }
}
