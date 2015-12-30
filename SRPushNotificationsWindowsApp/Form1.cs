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
using SRPushNotificationsWindowsApp.ServiceReference5;



namespace SRPushNotificationsWindowsApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            PushNotificationSend send = new PushNotificationSend();
            send.Title = textBoxTitle.Text;
            send.Message = textBoxMessage.Text;
            send.Topic = "global";
            send.NotificationKey = radioButtonIsTestNotification.Checked ? "AIzaSyDWkfA5KGwQDgGl03oB80OGCoo8iiJ_QP8" : "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";
            Service1Client client=new Service1Client();
            PushNotificationReturn ret=client.PushNotification(send);
            labelResults.Text = ret.SuccessMessage;
        }
    }
}
