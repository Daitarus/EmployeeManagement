using EmployeeManagementCLI.Models;

namespace EmployeeManagementCLI.Services
{
    public class EmployeeService
    {
        public Employees CreateMockEmployees()
        {
            var e1 = new Employee(1, "Name1", "LastName1", 3.1m);
            var e2 = new Employee(2, "Name2", "LastName2", 3.2m);
            var e3 = new Employee(3, "Name3", "LastName3", 3.3m);
            var e4 = new Employee(4, "Name4", "LastName4", 3.4m);
            var e5 = new Employee(5, "Name5", "LastName5", 3.5m);

            return new Employees()
            {
                EmployeesList = [e1, e2, e3, e4, e5]
            };
        }


    }
}
