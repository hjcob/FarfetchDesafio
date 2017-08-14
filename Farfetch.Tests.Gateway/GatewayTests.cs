using System.Threading.Tasks;
using FluentlyWindsor.EndersJson;
using FluentlyWindsor.EndersJson.Interfaces;
using NUnit.Framework;

namespace Farfetch.Tests.Gateway
{
    [TestFixture]
    public class GatewayTests : BaseTest
    {
        readonly IJsonService _client = new JsonService();


        [TestCase("api/farfetch/v1/MultiplyValueBy10/557", 5570)]
        [TestCase("api/farfetch/v1/MultiplyValueBy7/557", 3899)]
        [TestCase("api/farfetch/v1/DivisionValueBy7/81", 11.57)]
        [TestCase("api/farfetch/v1/DivisionValueBy10/81", 8.1)]
        [TestCase("api/farfetch/v2/StringLenght", "Henrique Jacob", 14)]
        public async Task Given_a_service_path_check_is_blocked(string pathService)
        {
            // Arrange UnBlock Services
            await _client.GetAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/blockallservices"));

            // Act
            var service = new ServicePath() { Path = pathService };
            var resultValue = await _client.PostAsync<dynamic>(string.Concat(UrlHost, pathService), service);

            // Assert
            Assert.That(resultValue, Is.EqualTo(""));


        }


        private class ServicePath
        {
            public string Path { get; set; }
        }
    }
}
