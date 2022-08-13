using Api.Application.Contracts.Config;
using Microsoft.Extensions.Configuration;

namespace Api.Application.Config
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ServiceUrl => _configuration.GetSection("ServiceUrl:Url").Value;
    }
}
