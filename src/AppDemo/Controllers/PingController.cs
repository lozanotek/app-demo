using System;
using System.Web.Http;

namespace AppDemo.Controllers
{
    public class PingViewModel
    {
        public DateTime ServerTime { get; set; }
    }
    public class PingController : ApiController
    {
        public PingViewModel Get()
        {
            return new PingViewModel { ServerTime = DateTime.Now };
        }
    }
}