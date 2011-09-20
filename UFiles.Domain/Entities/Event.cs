﻿using System;
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
        public DateTime Occured { get; set; }
    }
    [Table("FileAccessEvents")]
    public class FileAccessEvent : Event
    {

        public User User { get; set; }

        public File File { get; set; }
    }
    [Table("TransmittalEvents")]
    public class TransmittalEvent : Event{

        public Transmittal Transmittal{ get; set; }
    }
    [Table("UserEvents")]
    public class UserEvent : Event
    {

        public User User { get; set; }
    }
}
