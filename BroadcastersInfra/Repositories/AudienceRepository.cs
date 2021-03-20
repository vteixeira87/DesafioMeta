using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersInfra.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastersInfra.Repositories
{
    public class AudienceRepository : BaseRepository<Audience>, IAudienceRepository
    {
        public AudienceRepository(BroadcastersContext context) : base(context, "Audience")
        {
        }

        public async Task<Audience> GetAudienceByBroadcasterAndDateTimeAsync(string audienceBroadcaster, DateTime audienceDateTime)
            => await Collection.Find(x => x.AudienceBroadcaster.Equals(audienceBroadcaster.ToLower()) 
                                     && x.AudienceDateTime.Equals(audienceDateTime)
                                     && !x.IsDeleted).FirstOrDefaultAsync();

        public async Task<Audience> GetByIdAsync(string id)
            => await Collection.Find(x => x.Id.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();

        public async Task<List<Audience>> GetByNameAsync(string audienceBroadcaster)
            => await Collection.Find(x => x.AudienceBroadcaster.Equals(audienceBroadcaster.ToLower()) && !x.IsDeleted).ToListAsync();

    }
}
