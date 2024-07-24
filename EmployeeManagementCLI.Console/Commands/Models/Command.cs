namespace EmployeeManagementCLI.Console.Commands.Models
{
    public class Command
    {
        public CommandType Type { get; set; }

        public IEnumerable<CommandArgument> Arguments { get; set; }

        public Command(CommandType type, IEnumerable<CommandArgument> arguments)
        {
            Type = type;
            Arguments = arguments;
        }
    }

    public class CommandArgument
    {
        public ArgumentType Type { get; set; }
        public string Value { get; set; }

        public CommandArgument(ArgumentType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public enum CommandType
    {
        Unknown,
        Add,
        Update,
        Get,
        Delete,
        GetAll
    }

    public enum ArgumentType
    {
        Id,
        FirstName,
        LastName,
        SalaryPerHour
    }
}
