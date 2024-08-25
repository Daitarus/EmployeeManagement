namespace EmployeeManagement.Console.Commands.Models
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as Command);
        }


        public bool Equals(Command? other)
        {
            return other != null &&
                   Type == other.Type &&
                   Enumerable.SequenceEqual(Arguments, other.Arguments);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Arguments);
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as CommandArgument);
        }


        public bool Equals(CommandArgument? other)
        {
            return other != null &&
                   Type == other.Type &&
                   Value == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Value);
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
        Unknown,
        Id,
        FirstName,
        LastName,
        SalaryPerHour
    }
}
