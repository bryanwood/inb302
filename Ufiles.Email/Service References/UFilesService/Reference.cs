﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFiles.Email.UFilesService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UFilesService.IUFileService")]
    public interface IUFileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/Login", ReplyAction="http://tempuri.org/IUFileService/LoginResponse")]
        int Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/GetGroups", ReplyAction="http://tempuri.org/IUFileService/GetGroupsResponse")]
        UFiles.Domain.Entities.Group[] GetGroups(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/NewTransmittal", ReplyAction="http://tempuri.org/IUFileService/NewTransmittalResponse")]
        int NewTransmittal(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddFile", ReplyAction="http://tempuri.org/IUFileService/AddFileResponse")]
        int AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddTimeRangeRestriction", ReplyAction="http://tempuri.org/IUFileService/AddTimeRangeRestrictionResponse")]
        void AddTimeRangeRestriction(int fileId, UFiles.Domain.Entities.TimeRange[] timeRanges);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddUserRestriction", ReplyAction="http://tempuri.org/IUFileService/AddUserRestrictionResponse")]
        void AddUserRestriction(int fileId, string[] emails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddIPRestriction", ReplyAction="http://tempuri.org/IUFileService/AddIPRestrictionResponse")]
        void AddIPRestriction(int fileId, string[] IPs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddGroupRestriction", ReplyAction="http://tempuri.org/IUFileService/AddGroupRestrictionResponse")]
        void AddGroupRestriction(int fileId, int[] groupIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddLocationRestriction", ReplyAction="http://tempuri.org/IUFileService/AddLocationRestrictionResponse")]
        void AddLocationRestriction(int fileId, string[] postCodes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddRecipients", ReplyAction="http://tempuri.org/IUFileService/AddRecipientsResponse")]
        void AddRecipients(int transmittalId, string[] recipients);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/SendTransmittal", ReplyAction="http://tempuri.org/IUFileService/SendTransmittalResponse")]
        void SendTransmittal(int transmittalId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUFileServiceChannel : UFiles.Email.UFilesService.IUFileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UFileServiceClient : System.ServiceModel.ClientBase<UFiles.Email.UFilesService.IUFileService>, UFiles.Email.UFilesService.IUFileService {
        
        public UFileServiceClient() {
        }
        
        public UFileServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UFileServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UFileServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UFileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public UFiles.Domain.Entities.Group[] GetGroups(int userId) {
            return base.Channel.GetGroups(userId);
        }
        
        public int NewTransmittal(int userId) {
            return base.Channel.NewTransmittal(userId);
        }
        
        public int AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData) {
            return base.Channel.AddFile(userId, transmittalId, fileName, fileType, fileData);
        }
        
        public void AddTimeRangeRestriction(int fileId, UFiles.Domain.Entities.TimeRange[] timeRanges) {
            base.Channel.AddTimeRangeRestriction(fileId, timeRanges);
        }
        
        public void AddUserRestriction(int fileId, string[] emails) {
            base.Channel.AddUserRestriction(fileId, emails);
        }
        
        public void AddIPRestriction(int fileId, string[] IPs) {
            base.Channel.AddIPRestriction(fileId, IPs);
        }
        
        public void AddGroupRestriction(int fileId, int[] groupIds) {
            base.Channel.AddGroupRestriction(fileId, groupIds);
        }
        
        public void AddLocationRestriction(int fileId, string[] postCodes) {
            base.Channel.AddLocationRestriction(fileId, postCodes);
        }
        
        public void AddRecipients(int transmittalId, string[] recipients) {
            base.Channel.AddRecipients(transmittalId, recipients);
        }
        
        public void SendTransmittal(int transmittalId) {
            base.Channel.SendTransmittal(transmittalId);
        }
    }
}
