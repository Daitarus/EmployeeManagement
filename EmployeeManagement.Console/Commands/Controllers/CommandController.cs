using EmployeeManagement.Console.Commands.Controllers.Interfaces;
using EmployeeManagement.Console.Commands.Handler.Interfaces;
using EmployeeManagement.Console.Commands.Models;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Services.Interfaces;

namespace EmployeeManagement.Console.Commands.Controllers
{
    public class CommandController : ICommandController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IModelConverter<Command, Employee> _employeeConverter;
        private readonly IModelConverter<Command, int> _idConverter;
        private readonly IModelConverter<Message, string> _messageConverter;

        public CommandController(IEmployeeService employeeService, 
            IModelConverter<Command, Employee> employeeConverter, 
            IModelConverter<Command, int> idConverter, 
            IModelConverter<Message, string> messageConverter)
        {
            _employeeService = employeeService;
            _employeeConverter = employeeConverter;
            _idConverter = idConverter;
            _messageConverter = messageConverter;
        }

        public string Add(Command command)
        {
            if(command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.Add;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            var employee = _employeeConverter.Convert(command);
            var message = _employeeService.AddEmployee(employee);
            return _messageConverter.Convert(message);
        }

        public string Delete(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.Delete;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            var id = _idConverter.Convert(command);
            var message = _employeeService.DeleteEmployee(id);
            return _messageConverter.Convert(message);
        }

        public string Get(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.Get;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            var id = _idConverter.Convert(command);
            var message = _employeeService.GetEmployee(id);
            return _messageConverter.Convert(message);
        }

        public string GetAll(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.GetAll;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            var message = _employeeService.GetAllEmployees();
            return _messageConverter.Convert(message);
        }

        public string Unknown(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.Unknown;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            //TODO add UnknownCommandService
            return "There is no such command!";
        }

        public string Update(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var validCommandType = CommandType.Update;
            if (command.Type != validCommandType) throw new ArgumentException($"Command Type must be {validCommandType}", nameof(command));

            var employee = _employeeConverter.Convert(command);
            var message = _employeeService.UpdateEmployee(employee);
            return _messageConverter.Convert(message);
        }
    }
}
