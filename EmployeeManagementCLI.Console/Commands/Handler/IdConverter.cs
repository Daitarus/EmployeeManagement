using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Handler
{
    public class IdConverter : IModelConverter<Command, int>
    {
        public int Convert(Command model)
        {
            int id = 0;

            foreach(var argument in model.Arguments)
            {
                if (argument.Type == ArgumentType.Id)
                {
                    id = StringToInt(argument.Value);
                    break;
                }
            }

            return id;
        }

        private int StringToInt(string str)
        {
            int i;
            int.TryParse(str, out i);
            return i;
        }
    }
}
