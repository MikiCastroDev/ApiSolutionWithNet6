using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.DataAccess
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _entities;
        public Repository(DbContext context)
        {
            _entities = context.Set<T>();
        }
        void IRepository<T>.Add(T entity)
        {
            _entities.Add(entity);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            return _entities.ToList();
        }

        T IRepository<T>.GetById(long id)
        {
            return _entities.Find(id);
        }

        void IRepository<T>.Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
