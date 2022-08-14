using Api.Application.Contracts.Services;
using Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("Weather/{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            if (String.IsNullOrEmpty(city))
                return BadRequest();

            return Ok(await _service.GetWeatherByCity(city));
        }

        [HttpPost]
        public string RegisterOrder(OrderDTO order, bool sandbox)
        {
            return "Test";
        }
    }
}
