using Microsoft.AspNetCore.Mvc;

namespace ApiVersioninig.Controllers
{
    [Route( "api/v{version:apiVersion}/[controller]" )]
    [Route( "api/[controller]" )]
    public class ConventionsBasedController : Controller
    {
        #region V1
        
        [HttpGet]
        public string Get()
        {
            return "V1";
        }
        
        [HttpPost]
        public string Post()
        {
            return "V1";
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
        
        #endregion

        #region V2

        [HttpGet]
        public string GetV2()
        {
            return "V2";
        }
        
        [HttpPost]
        public string PostV2()
        {
            return "V2";
        }
        
        [HttpPut]
        public void PutV2()
        {
            return;
        }

        [HttpDelete] 
        public void DeleteV2()
        {
            return;
        }
        
        #endregion
        
        #region V3

        [HttpGet]
        public string GetV3()
        {
            return "V3";
        }
        
        [HttpPost]
        public string PostV3()
        {
            return "V3";
        }
        
        [HttpPut]
        public void PutV3()
        {
            return;
        }

        [HttpDelete] 
        public void DeleteV3()
        {
            return;
        }

        #endregion
    }
}