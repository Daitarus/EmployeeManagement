namespace EmployeeManagement.Domain.Entities
{
    public class Employee : Entity<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal SalaryPerHour { get; set; }
    }
}
