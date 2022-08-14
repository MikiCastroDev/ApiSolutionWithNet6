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
        public string WeatherStackUrl => _configuration.GetSection("WeatherStack:Url").Value;
        public string WeatherStackToken => _configuration.GetSection("WeatherStack:Token").Value;
        public string MongoDatabase => _configuration.GetSection("MongoDB:Database").Value;
        public string ConnectionStringMySQL => _configuration.GetSection("ConnectionStrings:PlanetScale").Value;
        public string ConnectionStringMongoDB => _configuration.GetSection("ConnectionStrings:MongoAtalas").Value;
    }
}
