using BroadcastersCrossCutting.Extension;
using BroadcastersDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Queries.Response
{
   public class BroadcastersResponse
    {
        public BroadcastersResponse() { }

        public int Id { get; set; }
        public string BroadcastersName { get; set; }

        public BroadcastersResponse(int id, string broadcastersName) 
        {
            Id = id;
            BroadcastersName = broadcastersName.CamelCase();
        }
    }
}
