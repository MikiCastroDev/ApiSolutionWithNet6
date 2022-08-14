using Api.Application.Contracts.Config;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.CrossCutting.Contracts.Objects;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Api.CrossCutting.ApiCaller
{
    public class ApiCaller : IApiCaller
    {
        #region Constants
        public string QUERY_PARAMS_FOR_WEATHERSTACK = "?access_key={0}&query={1}";
        #endregion

        private HttpClient _httpClient;
        private readonly IAppConfig config;

        public ApiCaller(IAppConfig appConfig)
        {
            config = appConfig;
        }

        public async Task<WeatherStackDTO> GetResponseFromWeatherStack(string city)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.WeatherStackUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(Constants.JSON_QUERY_HEADER));

            var response = await _httpClient.GetAsync(string.Format(QUERY_PARAMS_FOR_WEATHERSTACK
                                                                    , config.WeatherStackToken
                                                                    , city)); ;

            if (!response.IsSuccessStatusCode)
                return default(WeatherStackDTO);

            string result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WeatherStackDTO>(result);
        }
    }
}
