using BroadcastersCrossCutting.Entities;
using BroadcastersDomain.Contract;
using System;

namespace BroadcastersDomain.Entities
{
    public class Audience : BroadcastersAudit
    {
        public Audience() { }

        public Audience(string audienceBroadcaster, DateTime audienceDateTime, decimal audiencePoints)
        {
            AudienceBroadcaster = audienceBroadcaster.ToLower();
            AudienceDateTime = audienceDateTime;
            AudiencePoints = audiencePoints;

            AddNotifications(new AudienceContract(audienceBroadcaster, audienceDateTime, audiencePoints));
        }

        public string AudienceBroadcaster { get; private set; }
        public decimal AudiencePoints { get; private set; }
        public DateTime AudienceDateTime { get; private set; }

        public void AudienceRegister()
        {
            AddNotification("CreateAudiente", "Audiencia already registered for this broadcaster, on this day and time");
        }

        public void AudienceUnavailable()
        {
            AddNotification("AudienceDelete", "Non-existent Audience for delete");
        }

        public void Update(string audienceBroadcaster, decimal audiencePoints, DateTime audienceDateTime)
        {
            AudienceBroadcaster = audienceBroadcaster.ToLower();
            AudiencePoints = audiencePoints;
            AudienceDateTime = audienceDateTime;

            AddNotifications(new AudienceContract(audienceBroadcaster, audienceDateTime, audiencePoints));
        }

        public void NotAudienceForUpdate()
        {
            AddNotification("UpdateAudience", "Non-existent Audience for update");
        }
    }
}
