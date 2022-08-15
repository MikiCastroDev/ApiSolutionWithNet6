using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using MongoDB.Driver;

namespace Api.DataAccess.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : EntityMongo
    {
        protected readonly IMongoCollection<T> _dbSet;
        protected readonly MongoContext _context;

        public MongoRepository(MongoContext context)
        {
            _context = context;
            _dbSet = context.GetCollection<T>("Order");
        }

        public void Add(T entity)
        {
            _dbSet.InsertOne(entity);
        }

        public IEnumerable<T> GetAll()
        {
            var all = _dbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
