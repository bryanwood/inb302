﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFiles.Outlook.UFileService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UFileService.IUFileService")]
    public interface IUFileService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/Login", ReplyAction="http://tempuri.org/IUFileService/LoginResponse")]
        int Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/NewTransmittal", ReplyAction="http://tempuri.org/IUFileService/NewTransmittalResponse")]
        int NewTransmittal(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddFile", ReplyAction="http://tempuri.org/IUFileService/AddFileResponse")]
        void AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/AddRecipients", ReplyAction="http://tempuri.org/IUFileService/AddRecipientsResponse")]
        void AddRecipients(int transmittalId, string[] recipients);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUFileService/SendTransmittal", ReplyAction="http://tempuri.org/IUFileService/SendTransmittalResponse")]
        void SendTransmittal(int transmittalId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUFileServiceChannel : UFiles.Outlook.UFileService.IUFileService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UFileServiceClient : System.ServiceModel.ClientBase<UFiles.Outlook.UFileService.IUFileService>, UFiles.Outlook.UFileService.IUFileService {
        
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
        
        public int NewTransmittal(int userId) {
            return base.Channel.NewTransmittal(userId);
        }
        
        public void AddFile(int userId, int transmittalId, string fileName, string fileType, byte[] fileData) {
            base.Channel.AddFile(userId, transmittalId, fileName, fileType, fileData);
        }
        
        public void AddRecipients(int transmittalId, string[] recipients) {
            base.Channel.AddRecipients(transmittalId, recipients);
        }
        
        public void SendTransmittal(int transmittalId) {
            base.Channel.SendTransmittal(transmittalId);
        }
    }
}
