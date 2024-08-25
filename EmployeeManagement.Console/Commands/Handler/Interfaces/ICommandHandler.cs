using EmployeeManagement.Console.Commands.Models;

namespace EmployeeManagement.Console.Commands.Handler.Interfaces
{
    public interface ICommandHandler
    {
        public string Execute(Command command);
    }
}
