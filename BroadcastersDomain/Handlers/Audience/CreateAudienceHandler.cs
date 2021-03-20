using BroadcastersCrossCutting.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersDomain.Queries.Request;
using Flunt.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BroadcastersDomain.Handlers
{
    public class CreateAudienceHandler : Notifiable<Notification>, IRequestHandler<CreateAudienceCommand, NotificationResultDto>
    {
        private readonly IAudienceRepository _audienceRepository;
        private readonly IHandlerResponse _handlerResponse;

        public CreateAudienceHandler(IAudienceRepository audienceRepository, IHandlerResponse handlerResponse)
        {
            _audienceRepository = audienceRepository;
            _handlerResponse = handlerResponse;
        }


        public async Task<NotificationResultDto> Handle(CreateAudienceCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valid())
                    return _handlerResponse.Response(command.IsValid, command.Notifications);

                var audienteEntites = await _audienceRepository.GetAudienceByBroadcasterAndDateTimeAsync(command.AudienceBroadcaster, command.AudienceDateTime);

                var audience = new Audience(command.AudienceBroadcaster, command.AudienceDateTime, command.AudiencePoints);

                if (audienteEntites != null)
                    audience.AudienceRegister();

                if (audience.IsValid)
                    await _audienceRepository.InsertAsync(audience);

                AddNotifications(audience);

            }
            catch (Exception ex)
            {
                AddNotification("500", ex.Message);
            }

            return _handlerResponse.Response(IsValid, Notifications);
        }
    }
}
