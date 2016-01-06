using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Configuration;
using System.Diagnostics;

namespace Common {
    public class Scheduler {
        #region Variables
        private Timer mRefreshTimer = null;
        private int mPeriodicityInSeconds=120;
        private bool mIsEnabled=true;
        private DBController mDBController;
        private bool mWriteLogEntries;
        private DoesPushNotifications mDoesPushNotifications;
        #endregion
        #region Properties

        public int PeriodicityInMinutes {
            get { return mPeriodicityInSeconds; }
            set { mPeriodicityInSeconds = value; }
        }

        public bool IsEnabled {
            get {
                return mIsEnabled;
            }
            set {
                mIsEnabled = value;
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
            // fetch the latest control values
            startTimer();
        }
        /// <summary>
        /// Perform shutdown functions
        /// </summary>
        public void Stop() {
            stopTimer(true);
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
            milliSeconds = 1000;
            mRefreshTimer = new System.Timers.Timer(milliSeconds);
            mRefreshTimer.AutoReset = false;
            mRefreshTimer.Elapsed += new System.Timers.ElapsedEventHandler(mRefreshTimer_Elapsed);
            mRefreshTimer.Start();
        }
        /// <summary>
        /// Timer has "popped".  
        /// Synchronize database, and then re-set the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mRefreshTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            if (mIsEnabled) {
                writeEventLogEntry("Timer popped");
                mDBController.checkPushNotifications();
            }

            // TODO: For each "registered" longitude and latitude, lookup weather like this:
            // http://api.wunderground.com/api/bc2f8db95e1b5405/alerts/q/37.776289,-122.395234.json

            // reset the timer
            mRefreshTimer.Stop();
            mRefreshTimer = new System.Timers.Timer(mPeriodicityInSeconds*1000);
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
        #endregion
    }
}
