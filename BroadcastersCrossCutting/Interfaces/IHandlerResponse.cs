using BroadcastersCrossCutting.NotificationResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersCrossCutting.Interfaces
{
    public interface IHandlerResponse
    {
        NotificationResultDto Response(bool isValid, IReadOnlyCollection<Flunt.Notifications.Notification> notifications);
    }
}
