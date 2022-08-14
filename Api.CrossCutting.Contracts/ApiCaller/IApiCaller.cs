using Api.CrossCutting.Contracts.Objects;

namespace Api.CrossCutting.Contracts.ApiCaller
{
    public interface IApiCaller
    {
        Task<WeatherDTO> GetResponseFromWeatherStack(string city);
    }
}
