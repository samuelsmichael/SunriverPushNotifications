using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Common {
    public class DBController {
        #region Variables
        private DoesPushNotifications mDoesPushNotifications;
        /*TODO PUBLISH*/
        /*
         * For internal testing (only I will see the alerts), use alerttestinternal.
         * For testing (only non-published versions will see alerts), use alerttest.
         * For production, use alert
        */
        private static string ALERTTOPIC = "alerttestinternal";
        private static string EMERGENCYTOPIC = "emergencytestinternal";
        private static string NEWFEEDTOPIC = "newsfeedtestinternal";
        #endregion
        #region Constructor
        public DBController(DoesPushNotifications doesPushNotifications) {
            mDoesPushNotifications = doesPushNotifications;
        }
        #endregion
        #region Public Interface

        public void checkPushNotifications() {
            try {
                
                string retSuccessMessage = null;
                string sqlString="SELECT * FROM Alert WHERE isnull(ThisAlertHasBeenPushed,0)=0 AND isNull(isOnAlert,0)=1";
                DataSet ds=Utils.getDataSetFromQuery(
                    sqlString,
                    getConnectionString(ConfigurationManager.AppSettings["PushNotifications"])
                );
                if (Utils.hasData(ds)) {
                    foreach (DataRow dr in ds.Tables[0].Rows) {
                        mDoesPushNotifications.addToLog("Found Alert: "+Utils.ObjectToString(dr["ALID"]));
                        mDoesPushNotifications.pushNotification(
                            CommonRoutines.ObjectToStringV2(dr["ALTitle"]),
                            CommonRoutines.ObjectToStringV2(dr["ALDescription"]),
                            ALERTTOPIC,
                            null,
                            out retSuccessMessage);
                        mDoesPushNotifications.addToLog("Result of Push: "+retSuccessMessage);
                        sqlString = "UPDATE Alert SET ThisAlertHasBeenPushed=1 WHERE ALID=" + dr["ALID"];
                        Utils.executeNonQueryFromQueryString(sqlString, getConnectionString(ConfigurationManager.AppSettings["PushNotifications"]));
                    }
                }
            } catch (Exception e) {
                mDoesPushNotifications.addToLog("Error: "+e.ToString());
            }
        }
        #endregion

        #region Private Interface
        private string getConnectionString(string name) {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public void pushNotification(string title,string message, string topic, string emergencyMap, out string retSuccessMessage) {
            retSuccessMessage = "";/*
            PushNotificationSend send = new PushNotificationSend();
            send.Title = title;
            send.Message = message;
            send.Topic = topic;
            send.NotificationKey = "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";// radioButtonIsTestNotification.Checked ? "AIzaSyDWkfA5KGwQDgGl03oB80OGCoo8iiJ_QP8" : "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";
            send.EmergencyMapURL = emergencyMap;
            Service1Client client = new Service1Client();
            PushNotificationReturn ret = client.PushNotification(send);
            retSuccessMessage= ret.SuccessMessage;
             */
        }
        #endregion
    }
}
