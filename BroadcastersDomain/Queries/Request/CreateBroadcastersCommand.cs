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
    public class CreateBroadcastersCommand : Notifiable<Notification>, IRequest<NotificationResultDto>
    {  
        public string BrodcastersName { get; set; }
         

        public bool Valid()
        {
            Validate(this);
            return IsValid;
        }
        public void Validate(CreateBroadcastersCommand command)
        {
            AddNotifications(new BroadcastersContract (command.BrodcastersName)); 
        }

    }

}
