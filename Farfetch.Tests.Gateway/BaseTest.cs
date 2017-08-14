using System;
using Farfetch.Services;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Farfetch.Tests.Gateway
{
    public class BaseTest
    {
        private IDisposable OwinHost { get; set; }
        public const string UrlHost = "http://localhost:9091/";

        [OneTimeSetUp]
        public void Initialize()
        {
            OwinHost = WebApp.Start<Startup>(UrlHost);
        }


        [OneTimeTearDown]
        public void Finalize()
        {
            OwinHost.Dispose();
        }
    }
}
