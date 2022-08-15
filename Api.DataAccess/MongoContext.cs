using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Api.DataAccess
{
    public class MongoContext : IDisposable
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public MongoContext(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            string sandbox = System.Web.HttpUtility.ParseQueryString(httpContextAccessor.HttpContext.Request.QueryString.Value).Get("sandbox");

            if ((sandbox == null) || !Convert.ToBoolean(sandbox))
                _mongoClient = new MongoClient(configuration.GetConnectionString("MongoDevelopment"));
            else
                _mongoClient = new MongoClient(configuration.GetConnectionString("MongoProduction"));

            _db = _mongoClient.GetDatabase(configuration.GetValue<string>("MongoDB:Database"));
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
