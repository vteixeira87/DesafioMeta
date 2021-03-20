using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersCrossCutting.NotificationResult
{
    public class NotificationResultDto
    {
        public NotificationResultDto() { }

        public bool Sucess { get; set; }
        public object Notification { get; set; }


        public NotificationResultDto(bool isValid, object notification)
        {
            Sucess = isValid;
            Notification = notification;
        }
    }
}
