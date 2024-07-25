using EmployeeManagementCLI.Console.Commands.Handler.Interfaces;
using EmployeeManagementCLI.Domain.Models;
using EmployeeManagementCLI.Console.Commands.Models;

namespace EmployeeManagementCLI.Console.Commands.Handler
{
    public class EmployeeConverter : IModelConverter<Command, Employee>
    {
        public Employee Convert(Command model)
        {
            var employee = new Employee();

            foreach(var argument in model.Arguments)
            {
                TransferArgument(employee, argument);
            }

            return employee;
        }

        private void TransferArgument(Employee employee, CommandArgument argument)
        {
            switch (argument.Type)
            {
                case ArgumentType.Id: { employee.Id = StringToInt(argument.Value); break; }
                case ArgumentType.FirstName: { employee.FirstName = argument.Value; break; }
                case ArgumentType.LastName: { employee.LastName = argument.Value; break; }
                case ArgumentType.SalaryPerHour: { employee.SalaryPerHous = StringToDecimal(argument.Value); break; }
            };
        }

        private int StringToInt(string str)
        {
            int i;
            int.TryParse(str, out i);
            return i;
        }

        private decimal StringToDecimal(string str)
        {
            decimal d;
            decimal.TryParse(str, out d);
            return d;
        }
    }
}
