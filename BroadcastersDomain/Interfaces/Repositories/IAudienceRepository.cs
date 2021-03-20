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
        Task<List<Audience>> GetByNameAsync(string name);
        Task<Audience> GetByIdAsync(string id);
    }
}
