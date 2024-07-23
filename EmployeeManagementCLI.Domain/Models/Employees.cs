using EmployeeManagementCLI.Domain.Entities;

namespace EmployeeManagementCLI.Domain.Models
{
    public class Employees
    {
        public List<Employee> EmployeesList { get; set; } = new List<Employee>();
    }
}
