namespace Api.Application.Contracts.Services
{
    public interface IOrderService
    {
        string RegisterOrder();
        Task<string> GetWeatherByCity(string city);
    }
}
