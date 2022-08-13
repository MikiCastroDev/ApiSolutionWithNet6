namespace Api.DataAccess.Contracts
{
    public interface IMongoRepository<T>
    {
        public Task Add(T entity);
        public T GetById(long id);
        public IEnumerable<T> GetAll();
        public Task Remove(long id);
        public void Dispose();
    }
}
