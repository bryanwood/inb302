using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UFiles.Domain.Entities
{
    public class FileData
    {
        [Key]
        public int FileDataId { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string Hash { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
