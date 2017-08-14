using System;
using System.Web.Http;
using Farfetch.ApiGateWay.Core;
using Microsoft.Owin.Hosting;
using Owin;

namespace Farfetch.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string url = "http://localhost:8087";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Utilizar a url {0}.", url);
                Console.WriteLine("Presione qualquer tecla pra sair");
                Console.ReadLine();
            }
        }
    }

    public sealed class Startup
    {
        private readonly HttpConfiguration configuration_ = new HttpConfiguration();

        public void Configuration(IAppBuilder application)
        {

            application.UseHttpTracking();
            application.UseWebApi(configuration_);
            configuration_.MapHttpAttributeRoutes();
        }
    }
}
