using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Controllers.Interfaces
{
    public interface ICommandController
    {
        public string Add(Command command);

        public string Update(Command command);

        public string Delete(Command command);

        public string Get(Command command);

        public string GetAll(Command command);

        public string Unknown(Command command);
    }
}
