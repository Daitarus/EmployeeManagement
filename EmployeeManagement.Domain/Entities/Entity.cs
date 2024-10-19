using EmployeeManagement.Domain.Entities.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Domain.Entities
{
    public abstract class Entity<T> : IEntity<T> where T : struct, IIncrementOperators<T>
    {
        public T Id { get; set; } = default!;
    }
}
