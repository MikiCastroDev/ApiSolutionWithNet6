using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess.Contracts.Repositories
{
    public interface IOrderMongoRepository : IMongoRepository<OrderMongo>
    {
    }
}
