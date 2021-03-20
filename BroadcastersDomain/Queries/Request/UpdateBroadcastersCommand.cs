using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Contract;
using Flunt.Notifications;
using MediatR;


namespace BroadcastersDomain.Queries.Request
{
    public class UpdateBroadcastersCommand : Notifiable<Notification>, IRequest<NotificationResultDto>
    { 
        public int Id { get; set; }
        public string BrodcastersName { get; set; }
         

        public bool Valid()
        {
            Validate(this);
            return IsValid;
        }
        public void Validate(UpdateBroadcastersCommand command)
        {
            AddNotifications(new BroadcastersContract(command.Id, command.BrodcastersName)); 
        }

    }

}
