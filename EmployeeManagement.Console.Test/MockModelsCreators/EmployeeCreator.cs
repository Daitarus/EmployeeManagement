using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Console.Test.MockModelsCreators
{
    internal class EmployeeCreator
    {
        public static Employee? Null_model = null;
        public static Employee Empty_model = new Employee();

        public static Employee Only_id_model = new Employee() { Id = 14 };
        public static Employee No_id_model = new Employee() { FirstName = "testFirstName", LastName = "testLastName", SalaryPerHous = 34.1241223m };
        public static Employee No_Salary_model = new Employee() { Id = 14, FirstName = "testFirstName", LastName = "testLastName"};
        public static Employee Full_model = new Employee() { Id = 14, FirstName = "testFirstName", LastName = "testLastName", SalaryPerHous = 34.1241223m };

        public static Employee Only_negativ_id_model = new Employee() { Id = -24 };
        public static Employee Negativ_salary_model = new Employee() { Id = 14, FirstName = "testFirstName", LastName = "testLastName", SalaryPerHous = -37.3422214m };
    }
}
