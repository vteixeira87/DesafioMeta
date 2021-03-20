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
    public class UpdateAudienceHandler : Notifiable<Notification>, IRequestHandler<UpdateAudienceCommand, NotificationResultDto>
    {
        private readonly IAudienceRepository _audienceRepository;
        private readonly IHandlerResponse _handlerResponse;

        public UpdateAudienceHandler(IAudienceRepository audienceRepository, IHandlerResponse handlerResponse)
        {
            _audienceRepository = audienceRepository;
            _handlerResponse = handlerResponse;
        }

        public async Task<NotificationResultDto> Handle(UpdateAudienceCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valid())
                    return _handlerResponse.Response(command.IsValid, command.Notifications);

                var audienceEntites = await _audienceRepository.GetByIdAsync(command.Id);

                if (audienceEntites != null)
                {
                    var audience = await _audienceRepository.GetAudienceByBroadcasterAndDateTimeAsync(command.AudienceBroadcaster,command.AudienceDateTime);

                    if (audience != null)
                        audienceEntites.AudienceRegister();

                    if (audienceEntites.IsValid)
                    {
                        audienceEntites.Update(command.AudienceBroadcaster, command.AudiencePoints, command.AudienceDateTime);

                        if (audienceEntites.IsValid)
                            await _audienceRepository.UpdateAsync(audienceEntites);
                    }

                    AddNotifications(audienceEntites);
                }
                else
                {
                    var audience = new Audience();
                    audience.NotAudienceForUpdate();
                    AddNotifications(audience);
                }                       
            }
            catch (Exception ex)
            {
                AddNotification("500", ex.Message);
            }

            return _handlerResponse.Response(IsValid, Notifications);
        }
    }
}
