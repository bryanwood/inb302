using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UFiles.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUFileService" in both code and config file together.
    [ServiceContract]
    public interface IUFileService
    {
        [OperationContract]
        int Login(string username, string password);

        [OperationContract]
        int NewTransmittal(int userId);

        [OperationContract]
        void AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData);

        [OperationContract]
        void AddRecipients(int transmittalId, string[] recipients);

        [OperationContract]
        void SendTransmittal(int transmittalId);
    }
}
