using Api.Application.Contracts.DTOs;
using Api.DataAccess.Contracts.Entities;

namespace Api.Application.Contracts.Services
{
    public interface IOrderService
    {
        Task<OrderDTO?> RegisterOrder(OrderRequest order, bool sandbox);
        Task<WeatherDTO> GetWeatherByCity(string city);
    }
}
