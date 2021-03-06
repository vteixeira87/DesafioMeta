using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.BaseControler;
using BroadcastersDomain.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace BroadcastersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastersController : BaseController
    {
        private readonly IBroadcastersAppService _broadcastersAppService;

        public BroadcastersController(IBroadcastersAppService broadcastersAppService)
        {
            _broadcastersAppService = broadcastersAppService;
        }
         
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _broadcastersAppService.GetAllAsync();
            return GetResponse(response);
        } 

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var response = await _broadcastersAppService.GetByNameAsync(name);
            return GetResponse(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBroadcastersCommand command)
        {
            var notificationResult = await _broadcastersAppService.CreateAsync(command);
            return Response(notificationResult); 
        }

        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBroadcastersCommand command)
        {
            var notificationResult = await _broadcastersAppService.UpdatedAsync(command);
            return Response(notificationResult);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var notificationResult = await _broadcastersAppService.DeleteAsync(id);
            return Response(notificationResult);
        }
    }
}
