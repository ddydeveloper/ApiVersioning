using Microsoft.AspNetCore.Mvc;

namespace ApiVersioninig.Controllers
{
    [ApiVersionNeutral]
    [Route( "api/[controller]" )]
    public class HealthController : Controller
    {
        [HttpGet("ping")]
        public string Ping() => "Pong";
    }
}