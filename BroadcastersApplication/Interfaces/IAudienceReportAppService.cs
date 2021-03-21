using BroadcastersCrossCutting.Enum;
using BroadcastersDomain.Queries.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadcastersApplication.Interfaces
{
    public interface IAudienceReportAppService
    { 
        Task<List<AudienceReportResponse>> GetReportAsync(DateTime dateAudience, AudienceReportVisionEnum reportvisionEnum); 
    }
}
