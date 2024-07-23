using EmployeeManagementCLI.Models;
using EmployeeManagementCLI.Services;
using System;
using System.CommandLine;
using System.Text.Json;

namespace EmployeeManagementCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var employeeService = new EmployeeService();
            var employees = employeeService.CreateMockEmployees();

            using (var fs = new FileStream("Employees.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, employees);
            }

            Employees? newEmployees = null;
            using (FileStream fs = new FileStream("Employees.json", FileMode.OpenOrCreate))
            {
                newEmployees = await JsonSerializer.DeserializeAsync<Employees>(fs);
            }
        }
    }
}
