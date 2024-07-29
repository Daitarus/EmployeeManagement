using EmployeeManagementCLI.Console.Commands.Controllers.Interfaces;
using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Handler
{
    public class CommandHandler : ICommandHandler
    {
        private ICommandController _controller;

        public CommandHandler(ICommandController controller)
        {
            _controller = controller;
        }

        public string Execute(Command command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));

            return command.Type switch
            {
                CommandType.Add => _controller.Add(command),
                CommandType.Update => _controller.Update(command),
                CommandType.Delete => _controller.Delete(command),
                CommandType.Get => _controller.Get(command),
                CommandType.GetAll => _controller.GetAll(command),
                _ => _controller.Unknown(command)
            };
        }
    }
}
