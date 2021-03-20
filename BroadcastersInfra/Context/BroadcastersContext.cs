using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersInfra.Context
{
    public class BroadcastersContext
    {
        public IMongoDatabase _database { get; private set; }
        private MongoClient _client { get; set; }

        public BroadcastersContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration["ConnectionStrings:MongoDB:Uri"]);
            _database = _client.GetDatabase(configuration["ConnectionStrings:MongoDB:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
            => _database.GetCollection<T>(name);      
    }
}
