using EmployeeManagement.Domain.Entities.Interfaces;

namespace EmployeeManagement.Domain.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; } = default!;
    }
}
