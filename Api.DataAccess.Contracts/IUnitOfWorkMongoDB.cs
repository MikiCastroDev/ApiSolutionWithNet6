using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Contracts
{
    public interface IUnitOfWorkMongoDB  : IDisposable
    {
        #region Repository
        IOrderMongoRepository Orders { get; }
        #endregion
    }
}
