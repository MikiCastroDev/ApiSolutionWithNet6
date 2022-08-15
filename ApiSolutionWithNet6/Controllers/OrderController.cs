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

            WeatherDTO result = await _service.GetWeatherByCity(city);

            if (result == null || result == default(WeatherDTO))
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterOrder([FromBody]OrderRequest order, bool sandbox)
        {
            if (order == null)
                return BadRequest();

            OrderDTO result = (await _service.RegisterOrder(order, sandbox));

            if (result == null || result == default(OrderDTO))
                return NotFound();
            else
                return Ok(result);
        }
    }
}
