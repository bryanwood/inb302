using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class IPAddress
    {
        [Key]
        public int IPAddressId { get; set; }
        public string IP { get; set; }
        public virtual ICollection<IPRestriction> IPRestrictions { get; set; }
    }
}
