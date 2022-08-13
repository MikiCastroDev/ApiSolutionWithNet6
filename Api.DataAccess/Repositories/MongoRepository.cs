using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using MongoDB.Driver;

namespace Api.DataAccess.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : EntityMongo
    {
        protected readonly IMongoCollection<T> DbSet;
        protected readonly MongoContext _context;

        public MongoRepository(MongoContext context)
        {
            _context = context;
            DbSet = context.GetCollection<T>("Order");
        }

        public Task Add(T entity)
        {
            return _context.AddCommand(async () => await DbSet.InsertOneAsync(entity));
        }

        public T GetById(long id)
        {
            return DbSet.Find(Builders<T>.Filter.Eq(" id ", id.ToString())).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public Task Remove(long id) => _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq(" _id ", id)));

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
