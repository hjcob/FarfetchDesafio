using System.CodeDom;
using System.Web.Http;
using Farfetch.Data;

namespace Farfetch.Services.Gateway.Controller
{
    [RoutePrefix("api/farfetch")]
    public class GatewayController : ApiController
    {

        [HttpPost]
        [Route("v1/gateway/blockservice")]
        public bool BlockService(string path)
        {
            RedisManager.ServiceIsBlocked(path);
            return true;
        }

        [HttpPost]
        [Route("v1/gateway/unblockservice")]
        public bool UnBlockService(string path)
        {
            RedisManager.ServiceIsBlocked(path);
            return true;
        }
    }
}
