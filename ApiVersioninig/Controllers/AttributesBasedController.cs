using Microsoft.AspNetCore.Mvc;

namespace ApiVersioninig.Controllers
{
    [ApiVersion("1.0", Deprecated=true)]
    [ApiVersion("2.0")]
    [Route( "api/v{version:apiVersion}/[controller]" )]
    [Route( "api/[controller]" )]
    public class AttributesBasedController : Controller
    {
        #region V1
        
        [MapToApiVersion("1.0")]
        [HttpGet]
        public string Get()
        {
            return "V1";
        }
        
        [MapToApiVersion("1.0")]
        [HttpPost]
        public string Post()
        {
            return "V1";
        }
        
        [MapToApiVersion("1.0")]
        [HttpPut]
        public void Put()
        {
            return;
        }

        [MapToApiVersion("1.0")]
        [HttpDelete] 
        public void Delete()
        {
            return;
        }
        
        #endregion

        #region V2

        [MapToApiVersion("2.0")]
        [HttpGet]
        public string GetV2()
        {
            return "V2";
        }
        
        [MapToApiVersion("2.0")]
        [HttpPost]
        public string PostV2()
        {
            return "V2";
        }
        
        [MapToApiVersion("2.0")]
        [HttpPut]
        public void PutV2()
        {
            return;
        }

        [MapToApiVersion("2.0")]
        [HttpDelete] 
        public void DeleteV2()
        {
            return;
        }
        
        #endregion

    }
}