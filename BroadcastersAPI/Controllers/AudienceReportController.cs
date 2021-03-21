using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.BaseControler;
using BroadcastersCrossCutting.Enum;
using BroadcastersDomain.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace BroadcastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceReportController : BaseController
    {
        private readonly IAudienceReportAppService _audienceReportAppService;

        public AudienceReportController(IAudienceReportAppService audienceReportAppService)
        {
            _audienceReportAppService = audienceReportAppService;
        }
         
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]DateTime audienceDate, AudienceReportVisionEnum reportVisionEnum )
        {
            var response = await _audienceReportAppService.GetReportAsync(audienceDate, reportVisionEnum);
            return GetResponse(response);
        }          
       
    }
}
