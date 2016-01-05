using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common {
    public interface DoesPushNotifications {
        void pushNotification(string title, string message, string topic, string emergencyMap, out string retSuccessMessage);
        void addToLog(string entry);
    }
}
