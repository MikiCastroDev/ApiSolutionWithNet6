using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;

namespace Api.DataAccess
{
    public class UnitOfWorkMySQL : IUnitOfWorkMySQL
    {
        readonly DatabaseContext _context;

        #region Repositories
        public IOrderRepository Orders { get;}
        #endregion

        public UnitOfWorkMySQL(DatabaseContext context)
        {
            _context = context;

            Orders = new OrderRepository(context);
        }

        int IUnitOfWorkMySQL.Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
