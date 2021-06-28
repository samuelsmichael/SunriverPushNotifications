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
        private static string ALERTTOPIC = "alert";
        private static string EMERGENCYTOPIC = "emergency";
        private static string NEWFEEDTOPIC = "newsfeed";
        #endregion
        #region Constructor
        public DBController(DoesPushNotifications doesPushNotifications) {
            mDoesPushNotifications = doesPushNotifications;
        }
        #endregion
        #region Public Interface

        public void checkPushNotifications() {
            checkAlert(
                "SELECT * FROM Alert WHERE isnull(HasBeenPushed,0)=0 AND isNull(isOnAlert,0)=1",
                ALERTTOPIC,
                "ALTitle",
                "ALDescription",
                "ALID",
                "UPDATE Alert SET HasBeenPushed=1 WHERE ALID=",
                getConnectionString(ConfigurationManager.AppSettings["PushNotificationsAlert"]),
                false);
            checkAlert(
                "SELECT * FROM SRNewsfeed WHERE isnull(HasBeenPushed,0)=0 AND isNull(isOnNewsFeedAlert,0)=1",
                NEWFEEDTOPIC,
                "newsFeedTitle",
                "newsFeedDescription",
                "newsFeedID",
                "UPDATE SRNewsfeed SET HasBeenPushed=1 WHERE newsFeedID=",
                getConnectionString(ConfigurationManager.AppSettings["PushNotificationsNewsfeed"]),
                false);
            checkAlert(
                "SELECT * FROM SREmergency WHERE isnull(HasBeenPushed,0)=0 AND isNull(isEmergencyAlert,0)=1",
                EMERGENCYTOPIC,
                "emergencyTitle",
                "emergencyDescription",
                "emergencyID",
                "UPDATE SREmergency SET HasBeenPushed=1 WHERE emergencyID=",
                getConnectionString(ConfigurationManager.AppSettings["PushNotificationsEmergency"]),
                true);
        }
        #endregion

        #region Private Interface
        private void checkAlert(string sqlString, string topic, string titleFieldName, string descriptionFieldName, 
                string tableIDFieldName, string updateSQL, string connectionString, bool isEmergency) {
            try {
                string retSuccessMessage = null;
                DataSet ds=Utils.getDataSetFromQuery(
                    sqlString,
                    connectionString
                );
                string emergencyMap = null;
                if (Utils.hasData(ds)) {
                    if (isEmergency) {
                        DataSet dsEmergency = Utils.getDataSetFromQuery(
                            "SELECT TOP 1 * FROM SREmergencyMaps WHERE EmergencyMapsIsVisible=1",
                            getConnectionString(ConfigurationManager.AppSettings["PushNotificationsEmergencyMaps"]));
                        if (Utils.hasData(dsEmergency)) {
                            emergencyMap = Utils.ObjectToString(dsEmergency.Tables[0].Rows[0]["emergencyMapsURL"]);
                        }
                    }
                    foreach (DataRow dr in ds.Tables[0].Rows) {
                        mDoesPushNotifications.addToLog("Found " + topic + Utils.ObjectToString(dr[tableIDFieldName]));
                        mDoesPushNotifications.pushNotification(
                            CommonRoutines.ObjectToStringV2(dr[titleFieldName]),
                            CommonRoutines.ObjectToStringV2(dr[descriptionFieldName]),
                            topic,
                            emergencyMap,
                            out retSuccessMessage);
                        mDoesPushNotifications.addToLog("Result of Push: "+retSuccessMessage);
                        sqlString = updateSQL + dr[tableIDFieldName];
                        Utils.executeNonQueryFromQueryString(sqlString, getConnectionString(ConfigurationManager.AppSettings["PushNotificationsAlert"]));
                    }
                }
            } catch (Exception e) {
                mDoesPushNotifications.addToLog("Error doing "+topic+": "+e.ToString());
            }
        }
    

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
