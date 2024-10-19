using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Services.Interfaces;

namespace EmployeeManagement.Console.Test.MockModels
{
    internal class TestEmployeeService : IEmployeeService
    {
        public Message Create(EmployeeDto employee)
        {
            return new Message(ActionStatus.Success, "add");
        }

        public Message Delete(int id)
        {
            return new Message(ActionStatus.Success, "delete");
        }

        public Message GetAll()
        {
            return new Message(ActionStatus.Success, "getall");
        }

        public Message GetEmployee(int id)
        {
            return new Message(ActionStatus.Success, "get");
        }

        public Message UpdateEmployee(EmployeeDto employee)
        {
            return new Message(ActionStatus.Success, "update");
        }
    }
}
