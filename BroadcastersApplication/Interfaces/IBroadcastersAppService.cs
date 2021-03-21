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
    public interface IBroadcastersAppService
    {
        Task<NotificationResultDto> CreateAsync(CreateBroadcastersCommand command);
        Task<NotificationResultDto> UpdatedAsync(UpdateBroadcastersCommand command);
        Task<NotificationResultDto> DeleteAsync(string id);         
        Task<List<BroadcastersResponse>> GetAllAsync();
        Task<BroadcastersResponse> GetByNameAsync(string name); 
    }
}
