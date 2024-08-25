using EmployeeManagement.Console.Commands.Controllers.Interfaces;
using EmployeeManagement.Console.Commands.Models;

namespace EmployeeManagement.Console.Test.MockModels
{
    internal class TestCommandController : ICommandController
    {
        public string Add(Command command)
        {
            return "add";
        }

        public string Delete(Command command)
        {
            return "delete";
        }

        public string Get(Command command)
        {
            return "get";
        }

        public string GetAll(Command command)
        {
            return "getall";
        }

        public string Unknown(Command command)
        {
            return "unknown";
        }

        public string Update(Command command)
        {
            return "update";
        }
    }
}
