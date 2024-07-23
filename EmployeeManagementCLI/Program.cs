using EmployeeManagementCLI.Models;
using EmployeeManagementCLI.Services;
using System;
using System.CommandLine;
using System.Text.Json;

namespace EmployeeManagementCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonService = new JsonService("Employees.json");
            var employeeService = new EmployeeService();

            var employees = employeeService.CreateMockEmployees();

            jsonService.WriteModel(employees);

            var newEmployees = jsonService.ReadModel<Employees>();
        }
    }
}
