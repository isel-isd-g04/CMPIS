using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                return "do tipo user";

            } else if (opType == "cmoi")
            {
                Response.StatusCode = 200;
                var result = Persistance.Instance.GetUserTransaction();

                return "CMOIS type";
            }

            Response.StatusCode = 400;
            return "Failed";
        }


    }
}
