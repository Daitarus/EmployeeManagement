using EmployeeManagementCLI.Data.Entities.Base;

namespace EmployeeManagementCLI.Data.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHous { get; set; }
    }
}
