using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.BaseControler;
using BroadcastersDomain.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace BroadcastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceController : BaseController
    {
        private readonly IAudienceAppService _audienceAppService;

        public AudienceController(IAudienceAppService audienceAppService)
        {
            _audienceAppService = audienceAppService;
        }
         
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime audienceDate)
        {
            var response = await _audienceAppService.GetAllByDateAsync(audienceDate);
            return GetResponse(response);
        }
          
        [HttpGet("/name")]
        public async Task<IActionResult> GetByName([FromQuery] DateTime audienceDate, string name)
        {
            var response = await _audienceAppService.GetByDateAndNameAsync(name, audienceDate);
            return GetResponse(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAudienceCommand command)
        {
            var notificationResult = await _audienceAppService.CreateAsync(command);
            return Response(notificationResult); 
        }

        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateAudienceCommand command)
        {
            var notificationResult = await _audienceAppService.UpdatedAsync(command);
            return Response(notificationResult);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var notificationResult = await _audienceAppService.DeleteAsync(id);
            return Response(notificationResult);
        }
    }
}
