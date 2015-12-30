using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;


namespace SunriverNotificationsWcfService {
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class Service1 : IService1 {
        public PushNotificationReturn PushNotification(PushNotificationSend send) {
            PushNotificationReturn ret = new PushNotificationReturn();
            try {
                NotificationManager nm = new NotificationManager(send.Title, send.Message, send.Topic,send.NotificationKey,send.EmergencyMapURL);
                String result=nm.SendNotification();
                ret.SuccessMessage = result;
                ret.WCFCallSuccess = true;
            } catch (Exception e) {
                ret.WCFCallSuccess = false;
                ret.StackTrace = "";
                ret.ErrorMessage = "";
                string bar = "";
                Exception eInternal = e;
                while (eInternal != null) {
                    ret.StackTrace += bar + (e.StackTrace==null?"":e.StackTrace);
                    ret.ErrorMessage += bar + (e.Message==null?"":e.Message);
                    bar = "|";
                }
            }
            return ret;
        }
    }
}
