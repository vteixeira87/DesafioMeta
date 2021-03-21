using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersDomain.Queries.Request;
using BroadcastersDomain.Queries.Response;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastersApplication.Service
{
    public class BroadcastersAppService : IBroadcastersAppService
    {
        private readonly IMediator _mediator;
        private readonly IBroadcastersRepository _broadcastersRepository;


        public BroadcastersAppService(IMediator mediator, IBroadcastersRepository broadcastersRepository)
        {
            _mediator = mediator;
            _broadcastersRepository = broadcastersRepository;
        }

        public async Task<NotificationResultDto> CreateAsync(CreateBroadcastersCommand command)
           => await _mediator.Send(command);

        public async Task<NotificationResultDto> UpdatedAsync(UpdateBroadcastersCommand command)
           => await _mediator.Send(command);      

        public async Task<List<BroadcastersResponse>> GetAllAsync()
        {
            var broadcastersList = await _broadcastersRepository.GetAllAsync();

            var broadcasterResponseList = new List<BroadcastersResponse>();

            foreach (var broadcasters in broadcastersList)
                broadcasterResponseList.Add(new BroadcastersResponse(broadcasters.Id, broadcasters.Name));

            return broadcasterResponseList.Any() ? broadcasterResponseList : null;
        }
         
        public async Task<BroadcastersResponse> GetByNameAsync(string name)
        {
            var broadcasters = await _broadcastersRepository.GetByNameAsync(name);

            if (broadcasters != null)
                return new BroadcastersResponse(broadcasters.Id, broadcasters.Name);
            else
                return null;
        }

        public async Task<NotificationResultDto> DeleteAsync(string id)
        { 

            var broadcasters = await _broadcastersRepository.GetByIdAsync(id);

            if (broadcasters != null)
            {
                await _broadcastersRepository.DeleteAsync(broadcasters);

               return new NotificationResultDto(true, null);
            }
            else
            {
                var brodcastersNotification = new Broadcasters();

                brodcastersNotification.BrodcastersUnavailable();
                return new NotificationResultDto(false, brodcastersNotification.Notifications);
            }             
        }
    }
}
