using System.Threading.Tasks;
using FluentlyWindsor.EndersJson;
using FluentlyWindsor.EndersJson.Interfaces;
using NUnit.Framework;

namespace Farfetch.Tests
{
    [TestFixture]
    public class ApisTests : BaseTest
    {
        readonly IJsonService _client = new JsonService();
        

        [TestCase("api/farfetch/v1/MultiplyValueBy10/557", 5570)]
        [TestCase("api/farfetch/v1/MultiplyValueBy10/13", 130)]
        public async Task Given_a_multiplication_service_by_10_should_be_multiplied_correctly(string pathService, object expectedResult)
        {
                var result = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));
                Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("api/farfetch/v1/MultiplyValueBy7/557", 3899)]
        [TestCase("api/farfetch/v1/MultiplyValueBy7/13", 91)]
        public async Task Given_a_multiplication_service_by_7_should_be_multiplied_correctly(string pathService, object expectedResult)
        {
            var result = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("api/farfetch/v1/DivisionValueBy7/81", 11.57)]
        [TestCase("api/farfetch/v1/DivisionValueBy7/13", 1.86)]
        public async Task Given_a_division_service_by_7_should_be_divided_correctly(string pathService, object expectedResult)
        {
            var result = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase("api/farfetch/v1/DivisionValueBy10/81", 8.1)]
        [TestCase("api/farfetch/v1/DivisionValueBy10/13", 1.3)]
        public async Task Given_a_division_service_by_10_should_be_divided_correctly(string pathService, object expectedResult)
        {
            var result = await _client.GetAsync<object>(string.Concat(UrlHost, pathService));
            Assert.That(result, Is.EqualTo(expectedResult));
        }



        [TestCase("api/farfetch/v2/StringLenght", "Henrique Jacob", 14)]
        [TestCase("api/farfetch/v2/StringLenght", "Farfetch", 8)]
        public async Task Given_a_string_lenght_service_must_get_number_characters(string pathService, string text, int expectedResult)
        {
            var msg = new Mensagem() { Text = text  };

            var result = await _client.PostAsync<int>(string.Concat(UrlHost, pathService), msg);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
