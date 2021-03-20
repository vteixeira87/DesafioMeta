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
    public class UpdateBroadcastersHandler : Notifiable<Notification>, IRequestHandler<UpdateBroadcastersCommand, NotificationResultDto>
    {
        private readonly IBroadcastersRepository _broadcastersRepository;
        private readonly IHandlerResponse _handlerResponse;

        public UpdateBroadcastersHandler(IBroadcastersRepository broadcastersRepository, IHandlerResponse handlerResponse)
        {
            _broadcastersRepository = broadcastersRepository;
            _handlerResponse = handlerResponse;
        }


        public async Task<NotificationResultDto> Handle(UpdateBroadcastersCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valid())
                    return _handlerResponse.Response(command.IsValid, command.Notifications);


                var broadcasterEntities = await _broadcastersRepository.GetByIdAsync(command.Id);

                if (broadcasterEntities != null)
                {
                    var broadcaster = await _broadcastersRepository.GetByNameAsync(command.BrodcastersName);

                    if (broadcaster != null)
                        broadcasterEntities.NameUnavailable();

                    if (broadcasterEntities.IsValid)
                    {
                        broadcasterEntities.Update(command.BrodcastersName);

                        if (broadcasterEntities.IsValid)
                            await _broadcastersRepository.UpdateAsync(broadcasterEntities);
                    }

                    AddNotifications(broadcasterEntities);
                }
                else
                {
                    var broadcasters = new Broadcasters();
                    broadcasters.NotBrodcastersForUpdate();
                    AddNotifications(broadcasters);
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
