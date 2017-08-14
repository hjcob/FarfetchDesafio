using Owin;

namespace Farfetch.ApiGateWay.Core
{
    public static class HttpTracking
    {
        public static IAppBuilder UseHttpTracking(this IAppBuilder builder)
        {
            return builder.Use<HttpMiddleware>();
        }
    }
}
