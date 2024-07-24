using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Factories.Interfaces
{
    public interface ICommandFactory
    {
        public Command Create(string[] args);
    }
}
