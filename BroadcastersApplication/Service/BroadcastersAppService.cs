using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersDomain.Queries.Request;
using MediatR;
using System.Collections.Generic;
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

        public Task<NotificationResultDto> UpdatedAsync(UpdateBroadcastersCommand command)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
            => await _mediator.Send(new DeleteAgencyCommand(code));

        public async Task<List<Broadcasters>> GetAllAsync()
           => await _broadcastersRepository.GetAllAsync();

        public async Task<Broadcasters> GetByIdAsync(int id)
           => await _broadcastersRepository.GetByIdAsync(id);

        public async Task<Broadcasters> GetByNameAsync(string name)
            => await _broadcastersRepository.GetByNameAsync(name);

    }
}
