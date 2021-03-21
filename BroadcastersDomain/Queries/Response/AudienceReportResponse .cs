using BroadcastersCrossCutting.Enum;
using BroadcastersCrossCutting.Extension;
using BroadcastersDomain.Entities;
using System;
using System.Linq;

namespace BroadcastersDomain.Queries.Response
{
    public class AudienceReportResponse
    {
        public AudienceReportResponse() { }

        public AudienceReportResponse(string audienceBroadcaster, decimal audiencePoints)
        {
            AudienceBroadcaster = audienceBroadcaster.CamelCase();
            AudiencePoints = audiencePoints;
        }

        public string AudienceBroadcaster { get; set; }
        public decimal AudiencePoints { get; set; }

        public static AudienceReportResponse SetAudience(AudienceReportVisionEnum reportvisionEnum, IGrouping<string, Audience> broadcasterAudience, string audienceBroadcaster)
        {
            decimal audience = 0;
            if (AudienceReportVisionEnum.SumAudience == reportvisionEnum)
                audience = broadcasterAudience.Sum(x => x.AudiencePoints);
            else
                audience = broadcasterAudience.Sum(x => x.AudiencePoints) / broadcasterAudience.Count();

            return new AudienceReportResponse(audienceBroadcaster, audience);
        }
    }
}
