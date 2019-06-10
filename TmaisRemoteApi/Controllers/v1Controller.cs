using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace TmaisRemoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class V1Controller : ControllerBase
    {
        // GET api/v1
        [HttpGet]
        public string Get()
        {
            return Startup.StartupTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        // GET api/v1/5
        [HttpGet("{opType}")]
        public ActionResult<string> Get(string opType)
        {
            if (opType == "user")
            {
                Response.StatusCode = 200;
                var result = Persistance.Instance.GetUserTransaction();
                var json = JsonConvert.SerializeObject(result);
                return json;

            } else if (opType == "cmoi")
            {
                Response.StatusCode = 200;
                var result = Persistance.Instance.GetUserTransaction();

                var json = JsonConvert.SerializeObject(result);
                return json;
            }

            Response.StatusCode = 400;
            return "Failed";
        }


    }
}
