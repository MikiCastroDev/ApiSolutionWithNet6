namespace Api.DataAccess.Contracts
{
    public interface IRepository<T>
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}
