using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Handler.Interfaces
{
    public interface ICommandHandler
    {
        public string Execute(Command command);
    }
}
