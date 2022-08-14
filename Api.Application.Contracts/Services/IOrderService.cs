using Api.Application.Contracts.DTOs;

namespace Api.Application.Contracts.Services
{
    public interface IOrderService
    {
        string RegisterOrder(OrderDTO order, bool sandbox);
        Task<WeatherDTO> GetWeatherByCity(string city);
    }
}
