using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Console.Test.MockModelsCreators
{
    internal class EmployeeCreator
    {
        public static EmployeeDto? Null_model = null;
        public static EmployeeDto Empty_model = new EmployeeDto();

        public static EmployeeDto Only_id_model = new EmployeeDto() { Id = 14 };
        public static EmployeeDto No_id_model = new EmployeeDto() { FirstName = "testFirstName", LastName = "testLastName", SalaryPerHour = 34.1241223m };
        public static EmployeeDto No_Salary_model = new EmployeeDto() { Id = 14, FirstName = "testFirstName", LastName = "testLastName"};
        public static EmployeeDto Full_model = new EmployeeDto() { Id = 14, FirstName = "testFirstName", LastName = "testLastName", SalaryPerHour = 34.1241223m };

        public static EmployeeDto Only_negativ_id_model = new EmployeeDto() { Id = -24 };
        public static EmployeeDto Negativ_salary_model = new EmployeeDto() { Id = 14, FirstName = "testFirstName", LastName = "testLastName", SalaryPerHour = -37.3422214m };
    }
}
