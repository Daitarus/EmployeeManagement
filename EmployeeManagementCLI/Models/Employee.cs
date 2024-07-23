namespace EmployeeManagementCLI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SalaryPerHous { get; set; }

        public Employee() { }

        public Employee(int id, string firstName, string lastName, decimal salaryPerHous)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SalaryPerHous = salaryPerHous;
        }
    }
}
