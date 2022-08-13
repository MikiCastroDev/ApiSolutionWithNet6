using Api.DataAccess.Contracts.Entities;
using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Repositories
{
    public class OrderMongoRepository : MongoRepository<OrderMongo>, IOrderMongoRepository
    {
        public OrderMongoRepository(MongoContext context) : base(context) { }
    }
}
