using BroadcastersCrossCutting.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersCrossCutting.HandlerResponseCross
{
    public class HandlerResponse : IHandlerResponse
    {
        public NotificationResultDto Response(bool isValid, IReadOnlyCollection<Notification> notifications)
            => new NotificationResultDto(isValid, notifications);
       
    }
}
