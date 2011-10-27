using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFiles.Email
{
    public class UploadFile
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ContentType { get; set; }
        public List<string> Emails { get; set; }
        public List<int> Groups { get; set; }
    }
}
