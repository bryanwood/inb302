using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class Transmittal
    {
        [Key]
        public int TransmittalId { get; set; }

        public virtual ICollection<User> Recipients { get; set; }

        public bool Sent { get; set; }

        public User Sender { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
        
        public virtual ICollection<TransmittalEvent> TransmittalEvents { get; set; }
    }
}
