using EmployeeManagement.Domain.Entities.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Data.Contexts.Interfaces
{
    public interface IContext<TEntity, in T> where TEntity : IEntity<T> where T : struct, IIncrementOperators<T>
    {
        public TEntity AddEntity(TEntity entity);

        public TEntity? GetEntity(T id);

        public IEnumerable<TEntity> GetAllEntities();

        public void DeleteEntity(T id);

        public void SaveChanges();
    }
}
