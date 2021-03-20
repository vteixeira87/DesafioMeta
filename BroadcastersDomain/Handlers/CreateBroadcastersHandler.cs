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
    public class CreateBroadcastersHandler : Notifiable<Notification>, IRequestHandler<CreateBroadcastersCommand, NotificationResultDto>
    {
        private readonly IBroadcastersRepository _broadcastersRepository;
        private readonly IHandlerResponse _handlerResponse;

        public CreateBroadcastersHandler(IBroadcastersRepository broadcastersRepository, IHandlerResponse handlerResponse)
        {
            _broadcastersRepository = broadcastersRepository;
            _handlerResponse = handlerResponse;
        }


        public async Task<NotificationResultDto> Handle(CreateBroadcastersCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!command.Valid())
                    return _handlerResponse.Response(command.IsValid, command.Notifications);

                var broadcasterEntitie = await _broadcastersRepository.GetByNameAsync(command.BrodcastersName);

                var broadcaster = new Broadcasters(command.Id, command.BrodcastersName);

                if (broadcasterEntitie != null)
                    broadcaster.NameUnavailable();

                if (broadcaster.IsValid)
                    await _broadcastersRepository.InsertAsync(broadcaster);

                AddNotifications(broadcaster);

            }
            catch (Exception ex)
            {
                AddNotification("500", ex.Message);
            }

            return _handlerResponse.Response(IsValid, Notifications);
        }
    }
}
