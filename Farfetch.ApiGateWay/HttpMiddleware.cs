using System.Threading.Tasks;
using Farfetch.Data;
using Microsoft.Owin;

namespace Farfetch.ApiGateWay.Core
{
    public sealed class HttpMiddleware : OwinMiddleware
    {
        public HttpMiddleware(OwinMiddleware next) : base(next){ }
        public override async Task Invoke(IOwinContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var identity = request.User != null && request.User.Identity.IsAuthenticated ? request.User.Identity.Name : "(Usuário Anônimo)";
            if (RedisManager.ServiceIsBlocked(request.Path.ToString()))
            {
                response.OnSendingHeaders(state =>
                {
                    var resp = (OwinResponse)state;
                    resp.Headers.Add("X-Farfetch-Header", new[] { "Service Unavailable" });
                    resp.StatusCode = 503;
                    resp.ReasonPhrase = "Service Unavailable";
                }, response);

                await response.WriteAsync("{'message':'503 - Service Unavailable'}");
            }
            else
            {
                await Next.Invoke(context);
            }
        }
    }
}
