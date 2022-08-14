using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Api.DataAccess
{
    public class MongoContext : IDisposable
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public MongoContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration.GetConnectionString("MongoAtlas"));
            _db = _mongoClient.GetDatabase(configuration.GetValue<string>("MongoDB:Database"));
        }

        public int SaveChanges()
        {
            /*var qtd = _commands.Count;
            foreach (var command in _commands)
            {
                command();
            }

            _commands.Clear();*/
            return 0;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task AddCommand(Func<Task> func)
        {
            //_db.Add(func);
            return Task.CompletedTask;
        }
    }
}
