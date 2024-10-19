using EmployeeManagement.Domain.Entities.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Data.Models
{
    public class EntityCollection<TEntity, T> where TEntity : class, IEntity<T> where T : struct, IIncrementOperators<T>
    {
        public List<TEntity> Entities { get; set; } = new List<TEntity>();
    }
}
