using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersInfra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersInfra.Repositories
{
    public class AudienceRepository : BaseRepository<Audience>, IAudienceRepository
    {
        public AudienceRepository(BroadcastersContext context) : base(context, "Audience")
        {
        }
    }
}
