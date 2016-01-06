using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;


namespace SunriverNotificationsWcfService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1 {
        [OperationContract]
        PushNotificationReturn PushNotification(PushNotificationSend send);
    }

    [DataContract]
    public abstract class WcfReturn {
        [DataMember]
        public bool WCFCallSuccess { get; set; }
        [DataMember]
        public string SuccessMessage { get; set; }
        [DataMember]
        public string ErrorMessage {get; set;} 
        [DataMember]
        public string StackTrace {get; set;}
    }

    [DataContract]
    public abstract class WcfSend {
    }

    [DataContract]
    public class PushNotificationSend : WcfSend {
        [DataMember]
        public string Topic { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string NotificationKey { get; set; }
        [DataMember]
        public string EmergencyMapURL { get; set; }
    }
    [DataContract]
    public class PushNotificationReturn : WcfReturn {
        [DataMember]
        public string MessageID { get; set; }
    }
}
