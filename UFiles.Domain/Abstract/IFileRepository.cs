using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IFileRepository
    {
        IQueryable<File> Files { get; }
        void Save(File file);
        void Delete(File file);
    }
}