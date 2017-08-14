using System;
using Farfetch.Services;
using FluentlyWindsor.EndersJson;
using FluentlyWindsor.EndersJson.Interfaces;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Farfetch.Tests
{
    public class BaseTest
    {
        private IDisposable OwinHost { get; set; }
        public const string UrlHost = "http://localhost:8087/";
        readonly IJsonService _client = new JsonService();

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
