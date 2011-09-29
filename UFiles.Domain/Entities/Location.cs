using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [MaxLength(4),MinLength(4)]
        public string PostCode { get; set; }
        public virtual ICollection<LocationRestriction> LocationRestrictions { get; set; }
    }
}
