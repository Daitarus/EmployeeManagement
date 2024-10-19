using EmployeeManagement.Domain.Entities.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IRepository<TEntity, in T> where TEntity : class, IEntity<T> where T : struct, IIncrementOperators<T>
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity? GetById(T id);

        public TEntity Create(TEntity entity);

        public void CreateRange(IEnumerable<TEntity> entities);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);

        public void DeleteById(T id);

        public void DeleteRange(IEnumerable<TEntity> entities);
    }
}
