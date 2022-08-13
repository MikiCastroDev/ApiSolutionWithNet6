using Api.Application.Contracts.Services;
using Api.DTOs;
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

        [HttpGet]
        public string GetWeatherByCountry()
        {
            return _service.RegisterOrder();
        }

        [HttpPost]
        public string RegisterOrder(OrderDTO order, bool sandbox)
        {
            return "Test";
        }
    }
}
