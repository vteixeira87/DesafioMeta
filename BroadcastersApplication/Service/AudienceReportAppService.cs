using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.Enum;
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
    public class AudienceReportAppService : IAudienceReportAppService
    {
        private readonly IMediator _mediator;
        private readonly IAudienceRepository _audienceRepository;


        public AudienceReportAppService(IMediator mediator, IAudienceRepository audienceRepository)
        {
            _mediator = mediator;
            _audienceRepository = audienceRepository;
        }

        public async Task<List<AudienceReportResponse>> GetReportAsync(DateTime audienceDate, AudienceReportVisionEnum reportvisionEnum)
        {
            var audicenceReportResponse = new List<AudienceReportResponse>();

            var audienceList = await _audienceRepository.GetAudienceByDateTimeAsync(audienceDate.Date);

            var brodcasterAudienceList = audienceList.GroupBy(x => x.AudienceBroadcaster);
             
            foreach (var broadcasterAudience in brodcasterAudienceList)
                audicenceReportResponse.Add(AudienceReportResponse.SetAudience(reportvisionEnum, broadcasterAudience, broadcasterAudience.Key)); 

            return audicenceReportResponse.Any() ? audicenceReportResponse : null;

        }
    }
}
