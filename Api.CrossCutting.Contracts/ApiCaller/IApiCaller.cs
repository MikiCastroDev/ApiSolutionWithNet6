using Api.CrossCutting.Contracts.Objects;

namespace Api.CrossCutting.Contracts.ApiCaller
{
    public interface IApiCaller
    {
        Task<WeatherStackDTO> GetResponseFromWeatherStack(string city);
    }
}
