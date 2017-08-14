using System;
using System.Web.Http;

namespace Farfetch.Services
{
    [RoutePrefix("api/farfetch")]
    public class ApisController : ApiController
    {
        [HttpGet]
        [Route("v1/MultiplyValueBy10/{value}")]
        public int MultiplyValueBy10(int value)
        {
            var returnValue = value * 10;

            return returnValue;
        }

        [HttpGet]
        [Route("v1/MultiplyValueBy7/{value}")]
        public int MultiplyValueBy7(int value)
        {
            var returnValue = value * 7;

            return returnValue;
        }

        [HttpGet]
        [Route("v1/DivisionValueBy10/{value}")]
        public decimal DivisionValueBy10(decimal value)
        {
            decimal returnValue = Decimal.Round(value / 10, 2);

            return returnValue;
        }

        [HttpGet]
        [Route("v1/DivisionValueBy7/{value}")]
        public decimal DivisionValueBy7(decimal value)
        {
            decimal returnValue = Decimal.Round(value / 7, 2);

            return returnValue;
        }

        [HttpPost]
        [Route("v2/StringLenght")]
        public int StringLenght(Mensagem msg)
        {
           return msg.Text.Length;
        }
    }


    public class Mensagem
    {
        public string Text { get; set; }
    }
}
