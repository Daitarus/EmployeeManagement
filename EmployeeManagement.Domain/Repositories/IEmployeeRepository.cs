using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}
