using System;
using System.Threading.Tasks;
using FluentlyWindsor.EndersJson;
using FluentlyWindsor.EndersJson.Interfaces;
using NUnit.Framework;

namespace Farfetch.Tests
{
    [TestFixture]
    public class GatewayTests : BaseTest
    {
        readonly IJsonService _client = new JsonService();

        [TestCase("api/farfetch/v1/MultiplyValueBy10/557")]
        [TestCase("api/farfetch/v1/MultiplyValueBy7/557")]
        [TestCase("api/farfetch/v1/DivisionValueBy7/81")]
        [TestCase("api/farfetch/v1/DivisionValueBy10/81")]
        public async Task Given_a_service_path_check_is_blocked_get_verb(string pathService)
        {
            //Arrange all
            var service = new ServicePath() { Path = pathService };

            // Arrange Block Services
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/blockservice"), service);
            
            // Act
            var resultValue = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));

            // Assert
            Assert.IsTrue(resultValue.ToString().Contains("503 - Service Unavailable"));

            //Arrange UnblockService
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/unblockservice"), service);
        }

        [TestCase("api/farfetch/v1/MultiplyValueBy10/557", 5570)]
        [TestCase("api/farfetch/v1/MultiplyValueBy7/557", 3899)]
        [TestCase("api/farfetch/v1/DivisionValueBy7/81", 11.57)]
        [TestCase("api/farfetch/v1/DivisionValueBy10/81", 8.1)]
        public async Task Given_a_service_path_check_is_unblocked_get_verb(string pathService, object expectedResult)
        {
            //Arrange all
            var service = new ServicePath() { Path = pathService };

            // Arrange Block Services
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/unblockservice"), service);

            // Act
            var resultValue = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));

            // Assert
            Assert.That(resultValue, Is.EqualTo(expectedResult));
            
        }

        [TestCase("api/farfetch/v2/StringLenght", "Henrique Jacob")]
        [TestCase("api/farfetch/v2/StringLenght", "Farfetch")]
        public async Task Given_a_service_path_check_is_blocked_post_verb(string pathService, string text)
        {
          
            //Arrange all
            var service = new ServicePath() { Path = pathService };
            var msg = new Mensagem() { Text = text };

            // Arrange Block Services
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/blockservice"), service);

            // Act
            var result = await _client.PostAsync<object>(string.Concat(UrlHost, pathService), msg);

            // Assert
            Assert.IsTrue(result.ToString().Contains("503 - Service Unavailable"));

            //Arrange UnblockService
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/unblockservice"), service);
        }

        [TestCase("api/farfetch/v2/StringLenght", "Henrique Jacob", 14)]
        [TestCase("api/farfetch/v2/StringLenght", "Farfetch", 8)]
        public async Task Given_a_service_path_check_is_unblocked_post_verb(string pathService, string text, object expectedResult)
        {
            //Arrange all
            var service = new ServicePath() { Path = pathService };
            var msg = new Mensagem() { Text = text };

            // Arrange Block Services
            await _client.PostAsync(string.Concat(UrlHost, "api/farfetch/v1/gateway/unblockservice"), service);

            // Act
            var result = await _client.PostAsync<object>(string.Concat(UrlHost, pathService), msg);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

    }
}