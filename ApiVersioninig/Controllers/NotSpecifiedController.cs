using Microsoft.AspNetCore.Mvc;

namespace ApiVersioninig.Controllers
{
    [Route( "api/[controller]" )]
    public class NotSpecifiedController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Version not specified";
        }
    }
}