using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
