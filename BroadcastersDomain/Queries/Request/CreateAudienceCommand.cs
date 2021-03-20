using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Contract;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace BroadcastersDomain.Queries.Request
{
    public class CreateAudienceCommand : Notifiable<Notification>, IRequest<NotificationResultDto>
    {
        public string AudienceBroadcaster { get; set; }
        public decimal AudiencePoints { get; set; }
        public DateTime AudienceDateTime { get; set; }
       

        public bool Valid()
        {
            Validate(this);
            return IsValid;
        }
        public void Validate(CreateAudienceCommand command)
        {
            AddNotifications(new AudienceContract(command.AudienceBroadcaster, command.AudienceDateTime, command.AudiencePoints));
        }
    }
}
