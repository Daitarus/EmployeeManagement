using EmployeeManagementCLI.Console.Commands.Factories.Interfaces;
using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public Command? Create(string[] args)
        {
            if(args.Length == 0) return null;

            var commandName = args[0];
            args = args[1..args.Length];

            return new Command(ChoosingCommandType(commandName), CreateCommandArguments(args));
        }

        private CommandType ChoosingCommandType(string commandName)
        {
            return commandName switch
            {
                "-add" => CommandType.Add,
                "-update" => CommandType.Update,
                "-get" => CommandType.Get,
                "-delete" => CommandType.Delete,
                "-getall" => CommandType.GetAll,
                _ => CommandType.Unknown
            };
        }

        private CommandArgument[] CreateCommandArguments(string[] args)
        {
            var commandArgument = new CommandArgument[args.Length];

            for (int i = 0; i < args.Length; i++) 
            {
                commandArgument[i] = CreateCommandArgument(args[i]);
            }

            return commandArgument;
        }

        private CommandArgument CreateCommandArgument(string argumentString)
        {
            if(string.IsNullOrEmpty(argumentString))
            {
                return new CommandArgument(ArgumentType.Unknown, argumentString);
            }

            var argumentParts = argumentString.Split(':');

            if(argumentParts.Length <= 1)
            {
                return new CommandArgument(ArgumentType.Unknown, string.Empty);
            }

            return new CommandArgument(ChoosingArgumentType(argumentParts[0]), argumentParts[1]);
        }

        private ArgumentType ChoosingArgumentType(string argumetnName)
        {
            return argumetnName switch
            {
                "Id" => ArgumentType.Id,
                "FirstName" => ArgumentType.FirstName,
                "LastName" => ArgumentType.LastName,
                "Salary" => ArgumentType.SalaryPerHour,
                _ => ArgumentType.Unknown
            };
        }
    }
}
