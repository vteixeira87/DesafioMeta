using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Contract;
using Flunt.Notifications;
using MediatR;
using System;


namespace BroadcastersDomain.Queries.Request
{
    public class UpdateAudienceCommand : Notifiable<Notification>, IRequest<NotificationResultDto>
    {
        public string Id { get; set; }
        public string AudienceBroadcaster { get; set; }
        public decimal AudiencePoints { get; set; }
        public DateTime AudienceDateTime { get; set; }

        public bool Valid()
        {
            Validate(this);
            return IsValid;
        }
        public void Validate(UpdateAudienceCommand command)
        {
            AddNotifications(new AudienceContract(command.Id, command.AudienceBroadcaster, command.AudienceDateTime, command.AudiencePoints));
        }
    }
}
