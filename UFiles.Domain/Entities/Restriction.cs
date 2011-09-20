using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class Restriction
    {
        [Key]
        public int RestrictionId { get; set; }
    }
    [Table("UserRestrictions")]
    public class UserRestriction : Restriction
    {
        public virtual ICollection<User> Users { get; set; }
    }
    [Table("LocationRestrictions")]
    public class LocationRestriction : Restriction
    {
        public virtual ICollection<Location> Locations { get; set; }
    }
    [Table("IPRestrictions")]
    public class IPRestriction : Restriction
    {
        public virtual ICollection<IPAddress> IPAddress { get; set; }
    }
    [Table("GroupRestrictions")]
    public class GroupRestriction : Restriction
    {
        public virtual ICollection<Group> Groups{ get; set; }
    }
    [Table("TimeRangeRestrictions")]
    public class TimeRangeRestriction : Restriction
    {
        public virtual ICollection<TimeRange> TimeRanges { get; set; }
    }
   
    
}
