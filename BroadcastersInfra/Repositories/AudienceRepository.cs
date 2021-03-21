using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersInfra.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
         
        public async Task<List<Audience>> GetAudienceByDateTimeAsync(DateTime audienceDate)
        { 
            var filter = Builders.Gte("AudienceDateTime", audienceDate) & Builders.Lte("AudienceDateTime", audienceDate.AddDays(1).AddMilliseconds(-1))
                         & Builders.Eq("IsDeleted", false);

           return await Collection.Find(filter).ToListAsync();
        }

        public async Task<List<Audience>> GetAudienceByDateTimeAndNameAsync(DateTime audienceDate, string audienceBroadcaster)
        {
            var filter = Builders.Gte("AudienceDateTime", audienceDate) & Builders.Lte("AudienceDateTime", audienceDate.AddDays(1).AddMilliseconds(-1))
                         & Builders.Eq("IsDeleted", false) & Builders.Eq("AudienceBroadcaster", audienceBroadcaster);

            return await Collection.Find(filter).ToListAsync();
        }


        public async Task<Audience> GetByIdAsync(string id)
            => await Collection.Find(x => x.Id.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();
    }
}
