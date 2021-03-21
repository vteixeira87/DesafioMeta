using BroadcastersDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastersDomain.Interfaces.Repositories
{
    public interface IAudienceRepository : IBaseRepository<Audience>
    {
        Task<Audience> GetAudienceByBroadcasterAndDateTimeAsync(string audienceBroadcaster, DateTime audienceDateTime);
        Task<Audience> GetByIdAsync(string id);
        Task<List<Audience>> GetAudienceByDateTimeAsync(DateTime audienceDateTime);
        Task<List<Audience>> GetAudienceByDateTimeAndNameAsync(DateTime audienceDate, string audienceBroadcaster);
    }
}
