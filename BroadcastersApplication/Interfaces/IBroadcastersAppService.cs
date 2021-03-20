using BroadcastersCrossCutting.NotificationResult;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Queries.Request;
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
        Task<NotificationResultDto> DeleteAsync(int id);
        Task<Broadcasters> GetByIdAsync(int id);
        Task<List<Broadcasters>> GetAllAsync();
        Task<Broadcasters> GetByNameAsync(string name); 
    }
}
