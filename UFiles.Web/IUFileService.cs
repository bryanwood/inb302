using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UFiles.Domain.Entities;

namespace UFiles.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUFileService" in both code and config file together.
    [ServiceContract]
    public interface IUFileService
    {
        [OperationContract]
        int Login(string username, string password);

        [OperationContract]
        Group[] GetGroups(int userId);

        [OperationContract]
        Location[] GetLocations();

        [OperationContract]
        int NewTransmittal(int userId);

        [OperationContract]
        int AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData);

        [OperationContract]
        void AddUserRestriction(int fileId, string[] emails);

        [OperationContract]
        void AddIPRestriction(int fileId, string[] IPs);

        [OperationContract]
        void AddGroupRestruction(int fileId, int[] groupIds);

        [OperationContract]
        void AddLocationRestriction(int fileId, string[] postCodes);

        [OperationContract]
        void AddRecipients(int transmittalId, string[] recipients);

        [OperationContract]
        void SendTransmittal(int transmittalId);
    }
}
