using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Common {
    public class NotificationManager {
        private string _title;
        private string _message;
        private string _topic;
        //private static string NotificationKey = "AIzaSyDWkfA5KGwQDgGl03oB80OGCoo8iiJ_QP8";
        private string _NotificationKey = "AIzaSyA6lWELL3Ta-hRnG3632OyWS1l-PfwYpvI";
        private string NotificationKey {
            get {
                return _NotificationKey;
            }
        }

        public NotificationManager(String title, String message, string topic, string notificationKey) {
            _title = title;
            _message = message;
            _topic = topic;
            _NotificationKey = notificationKey;
        }

        public string SendNotification()
        {
            Stream dataStream = null;
            try {
                string postData = "{ \"to\" : \"/topics/" + _topic + "\", \"data\": {\"message\": \"" + _message + "\", \"contentTitle\": \"" + _title + "\" } }";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://gcm-http.googleapis.com/gcm/send");
                Request.Method = "POST";
                Request.KeepAlive = false;
                Request.ContentType = "application/json";
                Request.Headers.Add(string.Format("Authorization: key={0}", NotificationKey));
                Request.ContentLength = byteArray.Length;
                dataStream = Request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden)) {
                    //log
                } else if (!ResponseCode.Equals(HttpStatusCode.OK)) {
                    //log
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            } finally {
            }
        }
    }
}
