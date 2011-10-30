using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class File
    {
        [Key]
        public int FileId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Revoked { get; set; }
        public int Size { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }
        public User Owner { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        
        public virtual ICollection<Restriction> Restrictions { get; set; }
        
   
        
        public virtual ICollection<FileAccessEvent> FileAccessEvents { get; set; }
        
        public virtual ICollection<Transmittal> Transmittals { get; set; }
    }
}
