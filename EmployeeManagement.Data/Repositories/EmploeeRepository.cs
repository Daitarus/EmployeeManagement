using EmployeeManagement.Data.Contexts.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Data.Repositories
{
    public class EmploeeRepository : Repository<Employee, int>
    {
        public EmploeeRepository(IContext<Employee, int> context) : base(context) { }
    }
}
