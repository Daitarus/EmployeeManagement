using EmployeeManagement.Console.Commands.Models;

namespace EmployeeManagement.Console.Commands.Factories.Interfaces
{
    public interface ICommandFactory
    {
        public Command Create(string[]? args);
    }
}
