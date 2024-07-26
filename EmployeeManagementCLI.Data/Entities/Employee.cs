using EmployeeManagementCLI.Data.Entities.Base;

namespace EmployeeManagementCLI.Data.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHous { get; set; }

        public Employee() { }

        public Employee(Employee employee)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            SalaryPerHous = employee.SalaryPerHous;
        }
    }
}
