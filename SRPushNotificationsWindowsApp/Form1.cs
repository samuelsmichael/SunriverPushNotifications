using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using SRPushNotificationsWindowsApp.ServiceReference1;
using Common;



namespace SRPushNotificationsWindowsApp {
    public partial class Form1 : Form, DoesPushNotifications {
        private Scheduler mScheduler;
        public Form1() {
            InitializeComponent();
            mScheduler = new Scheduler(this);
        }

        private void button1_Click(object sender, EventArgs e) {
            string results;
            pushNotification(
                textBoxTitle.Text,
                textBoxMessage.Text,
                radioButtonAlertNotification.Checked?"alerttest":(radioButtonIsEmergency.Checked?"emergencytest":(radioButtonIsNewsfeed.Checked?"newsfeedtest":"global")),
                textBoxEmergencyMapURL.Text,
                out results);
            labelResults.Text = results;
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


        private void radioButtonAlertNotification_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked) {
                labelMapURL.Visible = false;
                textBoxEmergencyMapURL.Visible = false;
            }
        }

        private void radioButtonIsNewsfeed_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked) {
                labelMapURL.Visible = false;
                textBoxEmergencyMapURL.Visible = false;
            }
        }

        private void radioButtonIsEmergency_CheckedChanged(object sender, EventArgs e) {
            if (((RadioButton)sender).Checked) {
                labelMapURL.Visible = true;
                textBoxEmergencyMapURL.Visible = true;
            }
        }

        public void addToLog(string entry) {
            if (InvokeRequired) {
                // We're on a thread other than the GUI thread
                Invoke(new MethodInvoker(() => addToLog(entry)));
                return;
            }

            // Do what you need to do to the form here
            string[] logLines = textBoxLog.Lines;
            List<string> logLinesList = new List<string>(logLines);
            logLinesList.Add(entry);
            textBoxLog.Lines = logLinesList.ToArray();
        }

        private void buttonStartScheduler_Click(object sender, EventArgs e) {
            mScheduler.Start();
            buttonStartScheduler.Enabled = false;
            buttonStopScheduler.Enabled = true;
            addToLog("Scheduler started.");
        }

        private void buttonStopScheduler_Click(object sender, EventArgs e) {
            mScheduler.Stop();
            buttonStopScheduler.Enabled = false;
            buttonStartScheduler.Enabled = true;
            addToLog("Scheduler stopped.");
        }

        private void buttonClearLog_Click(object sender, EventArgs e) {
            textBoxLog.Clear();
        }
    }
}
