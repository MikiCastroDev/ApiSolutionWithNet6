namespace Api.Application.Contracts.Config
{
    public interface IAppConfig
    {
        string WeatherStackUrl { get; }
        string WeatherStackToken { get; }
        string MongoDatabase { get; }
        string ConnectionStringMySQL { get; }
        string ConnectionStringMongoDB { get; }
    }
}
