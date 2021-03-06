using BroadcastersCrossCutting.Interfaces;
using BroadcastersCrossCutting.NotificationResult;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace BroadcastersCrossCutting.BaseControler
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected new IActionResult Response(NotificationResultDto resultDto)
         => resultDto.Sucess ? (IActionResult)Ok(resultDto) : (IActionResult)BadRequest(resultDto);

        protected IActionResult GetResponse(object obj)
            => obj != null ? (IActionResult)Ok(obj) : (IActionResult)NoContent();
        
    }
}
