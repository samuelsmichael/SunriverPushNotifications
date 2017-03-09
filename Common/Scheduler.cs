using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace Common {
    public class Scheduler {

        /*
          Create a 2nd timer to handle wunderground; AND REMEMBER, if we find an alert, not only
          add it to dbo.Alert, but also mark as "not active" any existing such ones. And don't forget to
          put in the Expiration Date from what wunderground gives us.
        */ 

        #region Variables
        private Timer mRefreshTimer = null;
        private int mPeriodicityInSeconds=120;
        private bool mIsEnabled=true;
        private Timer mWeatherAlertRefreshTimer = null;
        private int mWeatherAlertPeriodicityInSeconds = 60 * 60;
        private bool mWeatherAlertIsEnabled = true;
        private DBController mDBController;
        private bool mWriteLogEntries;
        private DoesPushNotifications mDoesPushNotifications;
        #endregion
        #region Properties

        public int PeriodicityInSeconds {
            get { return mPeriodicityInSeconds; }
            set { mPeriodicityInSeconds = value; }
        }
        public int WeatherAlertPeriodicityInSeconds {
            get { return mWeatherAlertPeriodicityInSeconds; }
            set { mWeatherAlertPeriodicityInSeconds = value; }
        }
        public bool IsEnabled {
            get {
                return mIsEnabled;
            }
            set {
                mIsEnabled = value;
            }
        }
        public bool WeatherAlertIsEnabled {
            get {
                return mWeatherAlertIsEnabled;
            }
            set {
                mWeatherAlertIsEnabled = value;
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>

        /// <param name="source">Either the web app or the windows service</param>
        public Scheduler(DoesPushNotifications doesPushNotifications) {
            mDoesPushNotifications = doesPushNotifications;
            mDBController = new DBController(doesPushNotifications);
            mWriteLogEntries =
                CommonRoutines.ObjectToBool(ConfigurationManager.AppSettings["WriteLogEntries"]);
        }


        #endregion

        #region Public Interface
        /// <summary>
        /// Perform startup functions
        /// </summary>
        public void Start() {
            startWeatherAlertTimer();
            startTimer();
        }
        /// <summary>
        /// Perform shutdown functions
        /// </summary>
        public void Stop() {
            stopTimer(true);
            stopWeatherAlertTimer(true);
        }

        ///
        public void writeEventLogEntry(string entry) {
            if (mWriteLogEntries) {
                mDoesPushNotifications.addToLog(entry);
            }
        }

        #endregion

        #region Private Interface
        /// <summary>
        /// When starting the timer, set it so that it only pops once.  Then
        /// when it pops, start it again.
        /// </summary>
        private void startTimer() {
            stopTimer(false);
            double milliSeconds=mPeriodicityInSeconds*1000;
            /*The first time, we do it right away*/
            milliSeconds = 2000;
            mRefreshTimer = new System.Timers.Timer(milliSeconds);
            mRefreshTimer.AutoReset = false;
            mRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mRefreshTimer_Elapsed);
            mRefreshTimer.Start();
        }
        /// <summary>
        /// When starting the timer, set it so that it only pops once.  Then
        /// when it pops, start it again.
        /// </summary>
        private void startWeatherAlertTimer() {
            stopWeatherAlertTimer(false);
            double milliSeconds = mWeatherAlertPeriodicityInSeconds * 1000;
            /*The first time, we do it right away*/
            milliSeconds = 500;
            mWeatherAlertRefreshTimer = new System.Timers.Timer(milliSeconds);
            mWeatherAlertRefreshTimer.AutoReset = false;
            mWeatherAlertRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mWeatherAlertRefreshTimer_Elapsed);
            mWeatherAlertRefreshTimer.Start();
        }
        /// <summary>
        /// WeatherAlertTimer has "popped".  
        /// Check for weather alerts, and then re-set the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mWeatherAlertRefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (mWeatherAlertIsEnabled) {
                try {
                    writeEventLogEntry("Weather alert timer popped");

                    WebClient client = new WebClient();
                    // Add a user agent header in case the 
                    // requested URI contains a query.
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    string URL="http://api.wunderground.com/api/bc2f8db95e1b5405/alerts/q/" + ConfigurationManager.AppSettings["ZipCodeForWeatherAlerts"] + ".json";
                    writeEventLogEntry("Trying URL: "+URL);
                    Stream data = client.OpenRead(URL);

                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    Console.WriteLine(s);
                    data.Close();
                    reader.Close();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    dynamic mmm = jss.Deserialize<dynamic>(s);
                    object[] alerts = (object[])((Dictionary<string, object>)mmm)["alerts"];
                    if (alerts.Length > 0) {
                        writeEventLogEntry("Alert found.");
                        Object expires = ((Dictionary<string, object>)alerts[0])["expires"];
                        object epoch = ((Dictionary<string, object>)alerts[0])["expires_epoch"];
                        Object type = ((Dictionary<string, object>)alerts[0])["type"];
                        string emegencyTypeDescription = "";
                        switch ((string)type) {
                            case "HUR":
                                emegencyTypeDescription = "Hurricane Local Statement";
                                break;
                            case "TOR":
                                emegencyTypeDescription = "Tornado Warning";
                                break;
                            case "TOW":
                                emegencyTypeDescription = "Tornado Watch";
                                break;
                            case "WRN":
                                emegencyTypeDescription = "Severe Thunderstorm Warning";
                                break;
                            case "SEW":
                                emegencyTypeDescription = "Severe Thunderstorm Watch";
                                break;
                            case "WIN":
                                emegencyTypeDescription = "Winter Weather Advisory";
                                break;
                            case "FLO":
                                emegencyTypeDescription = "Flood Warning";
                                break;
                            case "WAT":
                                emegencyTypeDescription = "Flood Watch / Statement";
                                break;
                            case "WND":
                                emegencyTypeDescription = "High Wind Advisory";
                                break;
                            case "SVR":
                                emegencyTypeDescription = "Severe Weather Statement";
                                break;
                            case "HEA":
                                emegencyTypeDescription = "Heat Advisory";
                                break;
                            case "FOG":
                                emegencyTypeDescription = "Dense Fog Advisory";
                                break;
                            case "SPE":
                                emegencyTypeDescription = "Special Weather Statement";
                                break;
                            case "FIR":
                                emegencyTypeDescription = "Fire Weather Advisory";
                                break;
                            case "VOL":
                                emegencyTypeDescription = "Volcanic Activity Statement";
                                break;
                            case "HWW":
                                emegencyTypeDescription = "Hurricane Wind Warning";
                                break;
                            case "REC":
                                emegencyTypeDescription = "Record Set";
                                break;
                            case "REP":
                                emegencyTypeDescription = "Public Reports";
                                break;
                            case "PUB":
                                emegencyTypeDescription = "Public Information Statement";
                                break;
                            default:
                                emegencyTypeDescription = "Alert";
                                break;
                        }
                        object message = ((Dictionary<string, object>)alerts[0])["message"];
                        String messageString = ((string)message).Replace("'", " ");
                        // truncate to fit the size of dbo.Alert
                        int lengthOfMessage = 400;
                        if (messageString.Length < 400) {
                            lengthOfMessage = ((string)message).Length;
                        }
                        messageString = messageString.Substring(0, lengthOfMessage);


                        DateTime expiresAsDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        expiresAsDateTime = expiresAsDateTime.AddSeconds(Utils.ObjectToLong(epoch));
                        expiresAsDateTime = TimeZoneInfo.ConvertTimeFromUtc(expiresAsDateTime, TimeZoneInfo.Local);
                        Utils.executeNonQueryFromQueryString(
                            "UPDATE Alert SET isOnAlert=0",
                            getConnectionString(ConfigurationManager.AppSettings["PushNotificationsAlert"]));

                        Utils.executeNonQueryFromQueryString(
                            "Insert INTO Alert SELECT '" + emegencyTypeDescription + "','" + messageString +
                                "',1,'" + (expiresAsDateTime.ToString()) + "',0",
                            getConnectionString(ConfigurationManager.AppSettings["PushNotificationsAlert"]));
                    } else {
                        writeEventLogEntry("No alerts found.");
                    }
                } catch (Exception ee) {
                    writeEventLogEntry("ERROR: "+ee.Message);
                }
               
            }


            // reset the timer
            mWeatherAlertRefreshTimer.Stop();
            mWeatherAlertRefreshTimer = new System.Timers.Timer(mWeatherAlertPeriodicityInSeconds * 1000);
            mWeatherAlertRefreshTimer.AutoReset = false;
            mWeatherAlertRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mWeatherAlertRefreshTimer_Elapsed);
            mWeatherAlertRefreshTimer.Start();
        }
        /// <summary>
        /// Timer has "popped".  
        /// Check for push alert items, and then re-set the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mRefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (mIsEnabled) {
                writeEventLogEntry("Timer popped");
                mDBController.checkPushNotifications();
            }
            // reset the timer
            mRefreshTimer.Stop();
            mRefreshTimer = new System.Timers.Timer(mPeriodicityInSeconds * 1000);
            mRefreshTimer.AutoReset = false;
            mRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mRefreshTimer_Elapsed);
            mRefreshTimer.Start();
        }
        /// <summary>
        /// Stop the timer, if it's running
        /// </summary>
        private void stopTimer(bool writeLog) {
            if (writeLog) {
                writeEventLogEntry("Stopping timer loop.");
            }
            if (mRefreshTimer != null) {
                try {
                    mRefreshTimer.Stop();
                    mRefreshTimer.Dispose();
                } catch (Exception e) {
                }
            }
            mRefreshTimer = null;
        }
        /// <summary>
        /// Stop the timer, if it's running
        /// </summary>
        private void stopWeatherAlertTimer(bool writeLog) {
            if (writeLog) {
                writeEventLogEntry("Stopping weather alert timer loop.");
            }
            if (mWeatherAlertRefreshTimer != null) {
                try {
                    mWeatherAlertRefreshTimer.Stop();
                    mWeatherAlertRefreshTimer.Dispose();
                } catch (Exception e) {
                }
            }
            mWeatherAlertRefreshTimer = null;
        }
        private string getConnectionString(string name) {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion
    }
}
