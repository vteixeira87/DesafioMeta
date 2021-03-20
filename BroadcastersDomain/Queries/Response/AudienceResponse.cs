using BroadcastersCrossCutting.Extension;
using BroadcastersDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Queries.Response
{
   public class AudienceResponse
    {
        public AudienceResponse() { }

        public string Id { get; set; }
        public string AudienceBroadcaster { get; private set; }
        public decimal AudiencePoints { get; private set; }
        public DateTime AudienceDateTime { get; private set; }

        public AudienceResponse(string id, string audienceBroadcaster, decimal audiencePoints, DateTime audienceDateTime) 
        {
            Id = id;
            AudienceBroadcaster = audienceBroadcaster.CamelCase();
            AudiencePoints = audiencePoints;
            AudienceDateTime = audienceDateTime;

        }
    }
}
