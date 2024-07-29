namespace EmployeeManagementCLI.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? SalaryPerHous { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Employee);
        }


        public bool Equals(Employee? other)
        {
            return other != null &&
                   Id == other.Id &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   SalaryPerHous == SalaryPerHous;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, SalaryPerHous);
        }
    }
}
