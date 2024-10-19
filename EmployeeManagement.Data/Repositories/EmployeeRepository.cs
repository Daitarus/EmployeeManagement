using EmployeeManagement.Data.Contexts.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;

namespace EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(IContext<Employee, int> context) : base(context) { }
    }
}
