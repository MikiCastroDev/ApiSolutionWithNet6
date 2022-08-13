using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;

namespace Api.DataAccess
{
    public class UnitOfWorkMongoDB : IUnitOfWorkMongoDB
    {
        readonly MongoContext _context;

        #region Repositories
        public IOrderMongoRepository Orders { get; }
        #endregion

        public UnitOfWorkMongoDB(MongoContext context)
        {
            _context = context;

            Orders = new OrderMongoRepository(context);
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
