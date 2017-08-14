using System.Web.Http;
using Farfetch.Data;

namespace Farfetch.Services
{
    [RoutePrefix("api/farfetch")]
    public class GatewayController : ApiController
    {

        [HttpPost]
        [Route("v1/gateway/blockservice")]
        public bool BlockService(ServicePath servicePath)
        {
            RedisManager.BlockService(servicePath.Path);
            return true;
        }

        [HttpPost]
        [Route("v1/gateway/unblockservice")]
        public bool UnblockService(ServicePath servicePath)
        {
            RedisManager.UnblockService(servicePath.Path);
            return true;
        }

        [HttpGet]
        [Route("v1/gateway/unblockallservices")]
        public void UnblockAllServices()
        {
            RedisManager.UnblockAllServices();
        }


        [HttpGet]
        [Route("v1/gateway/blockallservices")]
        public void BlockAllServices()
        {
            RedisManager.BlockAllServices();
        }
    }

    public class ServicePath
    {
        public string Path { get; set; }
    }
}
