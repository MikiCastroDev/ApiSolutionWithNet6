namespace Api.DataAccess.Contracts
{
    public interface IUnitOfWorkMongoDB : IDisposable
    {
        bool Commit();
    }
}
