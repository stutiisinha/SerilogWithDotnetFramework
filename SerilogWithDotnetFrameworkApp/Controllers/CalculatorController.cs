using System;
using System.Web.Http;

namespace CalculatorApi.Controllers
{
    public class CalculatorController : ApiController
    {
        [HttpGet]
        [Route("api/calculator/add")]
        public IHttpActionResult Add(double num1, double num2)
        {
            double result = num1 + num2;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/calculator/subtract")]
        public IHttpActionResult Subtract(double num1, double num2)
        {
            double result = num1 - num2;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/calculator/multiply")]
        public IHttpActionResult Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return Ok(result);
        }

        [HttpGet]
        [Route("api/calculator/divide")]
        public IHttpActionResult Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }

            double result = num1 / num2;
            return Ok(result);
        }
    }
}