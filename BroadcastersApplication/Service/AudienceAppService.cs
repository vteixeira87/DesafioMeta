using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersDomain.Queries.Request;
using BroadcastersDomain.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastersApplication.Service
{
    public class AudienceAppService : IAudienceAppService
    {
        private readonly IMediator _mediator;
        private readonly IAudienceRepository _audienceRepository;


        public AudienceAppService(IMediator mediator, IAudienceRepository audienceRepository)
        {
            _mediator = mediator;
            _audienceRepository = audienceRepository;
        }

        public async Task<NotificationResultDto> CreateAsync(CreateAudienceCommand command)
           => await _mediator.Send(command);

        public async Task<NotificationResultDto> UpdatedAsync(UpdateAudienceCommand command)
           => await _mediator.Send(command);

        public async Task<List<AudienceResponse>> GetAllByDateAsync(DateTime audienceDate)
        {
            var audienceList = await _audienceRepository.GetAudienceByDateTimeAsync(audienceDate);

            var audienceResponseList = new List<AudienceResponse>();

            foreach (var audience in audienceList)
                audienceResponseList.Add(new AudienceResponse(audience.Id, audience.AudienceBroadcaster, audience.AudiencePoints, audience.AudienceDateTime));

            return audienceResponseList.Any() ? audienceResponseList : null;
        }

        public async Task<List<AudienceResponse>> GetByDateAndNameAsync(string name, DateTime audienceDate)
        {
            var audienceList = await _audienceRepository.GetAudienceByDateTimeAndNameAsync(audienceDate, name);

            var audienceResponseList = new List<AudienceResponse>();

            foreach (var audience in audienceList)
                audienceResponseList.Add(new AudienceResponse(audience.Id, audience.AudienceBroadcaster, audience.AudiencePoints, audience.AudienceDateTime));

            return audienceResponseList.Any() ? audienceResponseList : null;
        }

        public async Task<NotificationResultDto> DeleteAsync(string id)
        {
            var audience = await _audienceRepository.GetByIdAsync(id);

            if (audience != null)
            {
                await _audienceRepository.DeleteAsync(audience);

                return new NotificationResultDto(true, null);
            }
            else
            {
                var audienceNotification = new Audience();

                audienceNotification.AudienceUnavailable();
                return new NotificationResultDto(false, audienceNotification.Notifications);
            }
        }      
    }
}
