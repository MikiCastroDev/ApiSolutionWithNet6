namespace Api.DataAccess.Contracts
{
    public interface IMongoRepository<T>
    {
        public void Add(T entity);
        public IEnumerable<T> GetAll();
        public void Dispose();
    }
}
