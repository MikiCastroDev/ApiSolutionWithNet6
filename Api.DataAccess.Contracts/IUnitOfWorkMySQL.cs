using Api.DataAccess.Contracts.Repositories;

namespace Api.DataAccess.Contracts
{
    public interface IUnitOfWorkMySQL : IDisposable
    {
        #region Repository
        IOrderRepository Orders { get; }
        #endregion

        int Commit();
    }
}
