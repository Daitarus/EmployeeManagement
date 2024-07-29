using EmployeeManagementCLI.Domain.Models;
using EmployeeManagementCLI.Domain.Services.Interfaces;

namespace EmployeeManagementCLI.Console.Test.MockModels
{
    internal class TestEmployeeService : IEmployeeService
    {
        public Message AddEmployee(Employee employee)
        {
            return new Message(ActionStatus.Success, "add");
        }

        public Message DeleteEmployee(int id)
        {
            return new Message(ActionStatus.Success, "delete");
        }

        public Message GetAllEmployees()
        {
            return new Message(ActionStatus.Success, "getall");
        }

        public Message GetEmployee(int id)
        {
            return new Message(ActionStatus.Success, "get");
        }

        public Message UpdateEmployee(Employee employee)
        {
            return new Message(ActionStatus.Success, "update");
        }
    }
}
