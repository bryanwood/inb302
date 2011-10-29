using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IFileService
    {
        File GetFileById(int id);
        bool UserCanAccessFile(int id, int userId, int locationId, string iPAddress);
        void CreateFile(File file);
        void RevokeFile(int id);
    }
}
