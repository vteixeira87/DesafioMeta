using BroadcastersCrossCutting.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Entities
{
    public class Audience : BroadcastersAudit
    {
        public string AudiencePoints { get; private set; }
        public string AudienceDateTime { get; private set; }
        public string AudienceIssuer { get; private set; }
    }
}
