using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Queries.Request;
using BroadcastersDomain.Queries.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastersApplication.Interfaces
{
    public interface IAudienceAppService
    {
        Task<NotificationResultDto> CreateAsync(CreateAudienceCommand command);
        Task<NotificationResultDto> UpdatedAsync(UpdateAudienceCommand command);
        Task<NotificationResultDto> DeleteAsync(string id);
        Task<List<AudienceResponse>> GetAllByDateAsync(DateTime audienceDate);
        Task<List<AudienceResponse>> GetByDateAndNameAsync(string name, DateTime audienceDate);
    }
}
