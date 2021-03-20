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
    public class BroadcastersRepository : BaseRepository<Broadcasters>, IBroadcastersRepository
    {
        public BroadcastersRepository(BroadcastersContext context) : base(context, "Brodcasters")
        {
        }

        public async Task<Broadcasters> GetByIdAsync(string id)
           => await Collection.Find(x => x.Id.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();

        public async Task<Broadcasters> GetByNameAsync(string name)
           => await Collection.Find(x => x.Name.ToLower() == name.ToLower() && !x.IsDeleted ).FirstOrDefaultAsync();
         

    }
}
