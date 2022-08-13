using Api.DataAccess.Contracts;

namespace Api.DataAccess
{
    public class UnitOfWorkMongoDB : IUnitOfWorkMongoDB
    {
        private readonly MongoContext _context;

        public UnitOfWorkMongoDB(MongoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
