using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UFiles.Domain.Concrete
{
    public class FileDataStorage
    {
        private string _path;
        public FileStream GetFileDataStream(Entities.File file)
        {
            var filePath = Path.Combine(_path, file.FileId.ToString());
            return new FileStream(filePath, FileMode.OpenOrCreate);
        }
    }
}
