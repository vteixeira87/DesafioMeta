using BroadcastersCrossCutting.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastersCrossCutting.BaseControler
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    { 
        public new IActionResult Response(NotificationResultDto resultDto)
        {
             
            if (resultDto.Sucess)
                return Ok(resultDto);
            else
                return BadRequest(resultDto);

        }
    }
}
