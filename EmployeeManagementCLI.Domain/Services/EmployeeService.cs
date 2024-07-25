using EmployeeManagementCLI.Data.Contexts.Interfaces;
using EmployeeManagementCLI.Domain.Models;
using EmployeeManagementCLI.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementCLI.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IContext<Data.Entities.Employee> _context;
        private readonly ILogger? _logger;

        public EmployeeService(IContext<Data.Entities.Employee> context, ILogger? logger = null)
        {
            _context = context;
            _logger = logger;
        }

        public Message AddEmployee(Employee employee)
        {
            
        }

        public Message DeleteEmployee(int id)
        {
            
        }

        public Message GetAllEmployees()
        {
            
        }

        public Message GetEmployee(int id)
        {
            
        }

        public Message UpdateEmployee(Employee employee)
        {
            
        }
    }
}
