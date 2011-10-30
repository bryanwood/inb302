using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime Occurred { get; set; }
    }
    [Table("FileAccessEvents")]
    public class FileAccessEvent : Event
    {

        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public File File { get; set; }
        [ForeignKey("File")]
        public int FileId { get; set; }
    }
    [Table("TransmittalEvents")]
    public class TransmittalEvent : Event{

        public Transmittal Transmittal{ get; set; }
        [ForeignKey("Transmittal")]
        public int TransmittalId { get; set; }
    }
    [Table("UserEvents")]
    public class UserEvent : Event
    {
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}