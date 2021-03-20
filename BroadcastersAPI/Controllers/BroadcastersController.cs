using BroadcastersApplication.Interfaces;
using BroadcastersCrossCutting.BaseControler;
using BroadcastersCrossCutting.Interfaces;
using BroadcastersDomain.Queries.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/<BroadcastersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BroadcastersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBroadcastersCommand command)
        {
            var notificationResult = await _broadcastersAppService.CreateAsync(command);
            return Response(notificationResult); 
        }

        // PUT api/<BroadcastersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BroadcastersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
