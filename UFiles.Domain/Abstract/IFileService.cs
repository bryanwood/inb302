using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Domain.Abstract
{
    public interface IFileService
    {
        /// <summary>
        /// Returns the File with the specified id
        /// </summary>
        /// <param name="id">id of the file</param>
        /// <returns>A File</returns>
        File GetFileById(int id);

        /// <summary>
        /// Determines weather a use has access to a file or not
        /// </summary>
        /// <param name="id">if of the file</param>
        /// <param name="userId">id of the user</param>
        /// <param name="locationId">Not in use</param>
        /// <param name="iPAddress">ip address of the user as a string</param>
        /// <returns></returns>
        bool UserCanAccessFile(int id, int userId, int locationId, string iPAddress);
    
        /// <summary>
        /// creates a new file in the database
        /// </summary>
        /// <param name="file">File to create</param>
        void CreateFile(File file);
        
        /// <summary>
        /// Revokes access to a file, only the owner may access it there after.
        /// </summary>
        /// <param name="id">id of the file to revoke</param>
        void RevokeFile(int id);
    }
}
