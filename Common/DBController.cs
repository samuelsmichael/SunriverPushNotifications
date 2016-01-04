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
        private String mSessionId;
        #endregion
        #region Constructor
        public DBController(string sessionId) {
            mSessionId = sessionId;
        }
        #endregion
        #region Public Interface
        public void setPushNotificationParameters(ref bool? isPushNotificationEnabled, ref int? periodicityInMinutes) {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try {
                conn = new SqlConnection(CommonMethods.getConnectionString(ConfigurationManager.AppSettings["SROCalendarProvider"]));
                conn.Open();                
                cmd = new SqlCommand("SRSSynchronizationControlGetAndSet", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (isSynchronizationEnabled.HasValue) {
                    cmd.Parameters.Add("@IsSynchronizationActive", SqlDbType.Bit).Value = isSynchronizationEnabled.Value;
                }
                if (periodicityInMinutes.HasValue) {
                    cmd.Parameters.Add("@SynchronizationPeriodicityInMinutes", SqlDbType.Int).Value = periodicityInMinutes.Value;
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (CommonRoutines.HasData(ds)) {
                    periodicityInMinutes = CommonRoutines.ObjectToInt(ds.Tables[0].Rows[0]["SynchronizationPeriodicityInMinutes"]);
                    isSynchronizationEnabled = CommonRoutines.ObjectToBool(ds.Tables[0].Rows[0]["IsSynchronizationActive"]);
                }
            } catch (Exception e) {
            } finally {
                try { cmd.Dispose(); } catch { }
                try { conn.Close(); } catch { }
            }
        }
        public void getPushNotificationParameters(
                out bool isPushNotificationEnabled, 
                out int periodicityInMinutes) {
            periodicityInMinutes = 60;
            isPushNotificationEnabled = true;
        }
        public void pushNotification() {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try {
                conn = new SqlConnection(getConnectionString(ConfigurationManager.AppSettings["PushAlerts"]));
            } finally {
            }
        }
        #endregion

        #region Private Interface
        private string getConnectionString(string name) {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion
    }
}
