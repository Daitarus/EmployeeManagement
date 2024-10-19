using EmployeeManagement.Domain.Entities.Interfaces;

namespace EmployeeManagement.Domain.Repository
{
    public interface IRepository<TEntity, in T> where TEntity : class, IEntity<T>
    {
        public List<TEntity> GetAll();

        public TEntity? GetById(T id);

        public TEntity Create(TEntity entity);

        public void CreateRange(IList<TEntity> entities);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);

        public void DeleteById(T id);

        public void DeleteRange(List<TEntity> entities);
    }
}
