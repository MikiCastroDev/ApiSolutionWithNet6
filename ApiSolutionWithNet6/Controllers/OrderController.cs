using Api.Application.Contracts.Services;
using Api.Application.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost()]
        public async Task<IActionResult> RegisterOrder([FromBody]OrderRequest order, bool sandbox)
        {
            if (order == null)
                return BadRequest();

            return Ok(await _service.RegisterOrder(order, sandbox));
        }
    }
}
