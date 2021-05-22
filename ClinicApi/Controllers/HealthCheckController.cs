using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicApi.Controllers
{
    [Route("")]
    public class HealthCheckController : ApiController
    {
        public string GetHme()
        {
            return "Index";
        }
    }
}
