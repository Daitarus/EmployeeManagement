using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Repository
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}
