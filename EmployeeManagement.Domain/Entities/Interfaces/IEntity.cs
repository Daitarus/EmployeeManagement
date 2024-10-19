using System.Numerics;

namespace EmployeeManagement.Domain.Entities.Interfaces
{
    public interface IEntity<T> where T : struct, IIncrementOperators<T>
    {
        public T Id { get; set; }
    }
}
