﻿using EmployeeManagement.Console.Commands.Handler.Interfaces;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Console.Commands.Models;
using System.Globalization;

namespace EmployeeManagement.Console.Commands.Handler
{
    public class EmployeeConverter : IModelConverter<Command, EmployeeDto>
    {
        public EmployeeDto Convert(Command model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var employee = new EmployeeDto();
            foreach(var argument in model.Arguments)
            {
                TransferArgument(employee, argument);
            }

            return employee;
        }

        private void TransferArgument(EmployeeDto employee, CommandArgument argument)
        {
            switch (argument.Type)
            {
                case ArgumentType.Id: { employee.Id = StringToInt(argument.Value); break; }
                case ArgumentType.FirstName: { employee.FirstName = argument.Value; break; }
                case ArgumentType.LastName: { employee.LastName = argument.Value; break; }
                case ArgumentType.SalaryPerHour: { employee.SalaryPerHour = StringToDecimal(argument.Value); break; }
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
            decimal.TryParse(str, CultureInfo.InvariantCulture, out d);
            return d;
        }
    }
}
