using Microsoft.AspNetCore.Mvc;

namespace ApiVersioninig.Controllers
{
    [ApiVersion("4.0")]
    [Route( "api/v{version:apiVersion}/[controller]" )]
    [Route( "api/[controller]" )]
    public class AttributesBasedV4Controller : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "V4";
        }
        
        [HttpPost]
        public string Post()
        {
            return "V4";
        }
        
        [HttpPut]
        public void Put()
        {
            return;
        }

        [HttpDelete] 
        public void Delete()
        {
            return;
        }
    }
}