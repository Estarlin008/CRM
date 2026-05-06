using Microsoft.AspNetCore.Mvc;

namespace CRMApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}

