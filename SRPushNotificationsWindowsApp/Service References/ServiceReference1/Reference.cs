﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRPushNotificationsWindowsApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfSend", Namespace="http://schemas.datacontract.org/2004/07/SunriverNotificationsWcfService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationSend))]
    public partial class WcfSend : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PushNotificationSend", Namespace="http://schemas.datacontract.org/2004/07/SunriverNotificationsWcfService")]
    [System.SerializableAttribute()]
    public partial class PushNotificationSend : SRPushNotificationsWindowsApp.ServiceReference1.WcfSend {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmergencyMapURLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NotificationKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TopicField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmergencyMapURL {
            get {
                return this.EmergencyMapURLField;
            }
            set {
                if ((object.ReferenceEquals(this.EmergencyMapURLField, value) != true)) {
                    this.EmergencyMapURLField = value;
                    this.RaisePropertyChanged("EmergencyMapURL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NotificationKey {
            get {
                return this.NotificationKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.NotificationKeyField, value) != true)) {
                    this.NotificationKeyField = value;
                    this.RaisePropertyChanged("NotificationKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Topic {
            get {
                return this.TopicField;
            }
            set {
                if ((object.ReferenceEquals(this.TopicField, value) != true)) {
                    this.TopicField = value;
                    this.RaisePropertyChanged("Topic");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WcfReturn", Namespace="http://schemas.datacontract.org/2004/07/SunriverNotificationsWcfService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationReturn))]
    public partial class WcfReturn : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SuccessMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool WCFCallSuccessField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SuccessMessage {
            get {
                return this.SuccessMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.SuccessMessageField, value) != true)) {
                    this.SuccessMessageField = value;
                    this.RaisePropertyChanged("SuccessMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool WCFCallSuccess {
            get {
                return this.WCFCallSuccessField;
            }
            set {
                if ((this.WCFCallSuccessField.Equals(value) != true)) {
                    this.WCFCallSuccessField = value;
                    this.RaisePropertyChanged("WCFCallSuccess");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PushNotificationReturn", Namespace="http://schemas.datacontract.org/2004/07/SunriverNotificationsWcfService")]
    [System.SerializableAttribute()]
    public partial class PushNotificationReturn : SRPushNotificationsWindowsApp.ServiceReference1.WcfReturn {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageID {
            get {
                return this.MessageIDField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageIDField, value) != true)) {
                    this.MessageIDField = value;
                    this.RaisePropertyChanged("MessageID");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushNotification", ReplyAction="http://tempuri.org/IService1/PushNotificationResponse")]
        SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationReturn PushNotification(SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationSend send);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PushNotificationRegister", ReplyAction="http://tempuri.org/IService1/PushNotificationRegisterResponse")]
        string PushNotificationRegister(string zipcode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : SRPushNotificationsWindowsApp.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<SRPushNotificationsWindowsApp.ServiceReference1.IService1>, SRPushNotificationsWindowsApp.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationReturn PushNotification(SRPushNotificationsWindowsApp.ServiceReference1.PushNotificationSend send) {
            return base.Channel.PushNotification(send);
        }
        
        public string PushNotificationRegister(string zipcode) {
            return base.Channel.PushNotificationRegister(zipcode);
        }
    }
}