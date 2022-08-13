using Api.Application.Contracts.Config;
using Api.CrossCutting.Contracts.ApiCaller;
using System.Net.Http.Headers;

namespace Api.CrossCutting.ApiCaller
{
    public class ApiCaller : IApiCaller
    {

        private readonly HttpClient _httpClient;

        public ApiCaller(IAppConfig appConfig)
        {

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(appConfig.ServiceUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
