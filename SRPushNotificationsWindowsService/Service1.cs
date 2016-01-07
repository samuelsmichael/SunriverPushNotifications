using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Common;
using SRPushNotificationsWindowsService.ServiceReference1;


namespace SRPushNotificationsWindowsService {
    public partial class Service1 : ServiceBase, DoesPushNotifications {
        public EventLog windowsLog = new EventLog("SR Push Notifications");
        private Scheduler mScheduler;
        public Service1() {
            InitializeComponent();
        }

        public void addToLog(string entry) {
            windowsLog.Source = "Windows Service";
            try {
                windowsLog.WriteEntry(entry);
            } catch { }
        }

        protected override void OnStart(string[] args) {
            mScheduler = new Scheduler(this);
            mScheduler.Start();
            mScheduler.writeEventLogEntry("Started Scheduler");
        }

        protected override void OnStop() {
            if (mScheduler != null) {
                mScheduler.Stop();
            }
        }

        public void pushNotification(string title, string message, string topic, string emergencyMap, out string retSuccessMessage) {
            PushNotificationSend send = new PushNotificationSend();
            send.Title = title;
            send.Message = message;
            send.Topic = topic;
            send.NotificationKey = "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";// radioButtonIsTestNotification.Checked ? "AIzaSyDWkfA5KGwQDgGl03oB80OGCoo8iiJ_QP8" : "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";
            send.EmergencyMapURL = emergencyMap;
            Service1Client client = new Service1Client();
            PushNotificationReturn ret = client.PushNotification(send);
            retSuccessMessage = ret.SuccessMessage;
        }
    }
}
