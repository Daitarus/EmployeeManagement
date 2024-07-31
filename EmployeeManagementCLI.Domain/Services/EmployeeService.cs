using EmployeeManagementCLI.Data.Contexts.Interfaces;
using EmployeeManagementCLI.Domain.Models;
using EmployeeManagementCLI.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EmployeeManagementCLI.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IContext<Data.Entities.Employee> _context;
        private readonly ILogger<EmployeeService>? _logger;

        public EmployeeService(IContext<Data.Entities.Employee> context, ILogger<EmployeeService>? logger = null)
        {
            _context = context;
            _logger = logger;
        }

        #region Service action
        public Message AddEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            if(string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName) || employee.SalaryPerHous == null)
            {
                _logger?.LogWarning($"[{nameof(AddEmployee)}]: Warning: not all data is filled for action!");
                return new Message(ActionStatus.NotSuccess, $"Warning: not all data is filled for action");
            }

            try
            {
                var salaryDecimal = (decimal)employee.SalaryPerHous;
                if (salaryDecimal < 0)
                {
                    _logger?.LogWarning($"[{nameof(AddEmployee)}]: Warning: Salary should be more than 0!");
                    return new Message(ActionStatus.NotSuccess, $"Warning: Salary should be more than 0");
                }

                var employeeEntity = new Data.Entities.Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    SalaryPerHous = salaryDecimal
                };

                employeeEntity = _context.AddEntity(employeeEntity);
                _context.SaveChanges();

                _logger?.LogInformation($"[{nameof(AddEmployee)}][Id = {employeeEntity.Id}]: Success!");
                return new Message(ActionStatus.Success, $"Employee was added (Id = {employeeEntity.Id})");
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(AddEmployee)}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message DeleteEmployee(int id)
        {
            try
            {
                if (_context.DeleteEntity(id))
                {
                    _context.SaveChanges();

                    _logger?.LogInformation($"[{nameof(DeleteEmployee)}][Id = {id}]: Success!");
                    return new Message(ActionStatus.Success, $"Employee with Id = {id} was deleted!");
                }
                else
                {
                    _logger?.LogWarning($"[{nameof(DeleteEmployee)}][Id = {id}]: Warning: no data available!");
                    return new Message(ActionStatus.NotSuccess, $"Warning: no data available");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(DeleteEmployee)}][Id = {id}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message GetAllEmployees()
        {
            try
            {
                var employees = _context.GetAllEntities();

                if (employees == null || employees?.Count() == 0)
                {
                    _logger?.LogWarning($"[{nameof(GetAllEmployees)}]: Warning: no data available!");
                    return new Message(ActionStatus.NotSuccess, "Warning: no data available!");
                }
                else
                {
                    var resultText = new StringBuilder();
                    foreach (var employee in employees)
                    {
                        resultText.AppendLine(CreateEmployeeInfoStr(employee));
                    }

                    _logger?.LogInformation($"[{nameof(GetAllEmployees)}]: Success!");
                    return new Message(ActionStatus.Success, resultText.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(GetAllEmployees)}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message GetEmployee(int id)
        {
            try
            {
                var employee = _context.GetEntity(id);

                if (employee == null)
                {
                    _logger?.LogWarning($"[{nameof(GetEmployee)}][Id = {id}]: Warning: no data available!");
                    return new Message(ActionStatus.NotSuccess, "Warning: no data available!");
                }
                else
                {
                    _logger?.LogInformation($"[{nameof(GetEmployee)}][Id = {id}]: Success!");
                    return new Message(ActionStatus.Success, CreateEmployeeInfoStr(employee));
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(GetEmployee)}][Id = {id}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message UpdateEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            try
            {
                var employeeEntity = _context.GetEntity(employee.Id);
                if (employeeEntity != null)
                {
                    bool wasChanges = false;

                    if (!string.IsNullOrEmpty(employee.FirstName))
                    {
                        wasChanges = true;
                        employeeEntity.FirstName = employee.FirstName;
                    }

                    if (!string.IsNullOrEmpty(employee.LastName))
                    {
                        wasChanges = true;
                        employeeEntity.LastName = employee.LastName;
                    }

                    if (employee.SalaryPerHous != null)
                    {
                        var salaryDecimal = (decimal)employee.SalaryPerHous;
                        if (salaryDecimal < 0)
                        {
                            _logger?.LogWarning($"[{nameof(AddEmployee)}]: Warning: Salary should be more than 0!");
                            return new Message(ActionStatus.NotSuccess, $"Warning: Salary should be more than 0");
                        }
                        else
                        {
                            wasChanges = true;
                            employeeEntity.SalaryPerHous = salaryDecimal;
                        }
                    }

                    if (wasChanges)
                    {
                        _context.SaveChanges();

                        _logger?.LogInformation($"[{nameof(UpdateEmployee)}][Id = {employeeEntity.Id}]: Success!");
                        return new Message(ActionStatus.Success, $"Employee with Id = {employeeEntity.Id} was updated!");
                    }
                    else
                    {
                        _logger?.LogWarning($"[{nameof(UpdateEmployee)}][Id = {employeeEntity.Id}]: Warning: no data available!");
                        return new Message(ActionStatus.NotSuccess, $"Warning: no data available");
                    }
                }
                else
                {
                    _logger?.LogWarning($"[{nameof(UpdateEmployee)}][Id = {employee.Id}]: Warning: no updated data!");
                    return new Message(ActionStatus.NotSuccess, $"Warning: no updated data");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(UpdateEmployee)}][Id = {employee.Id}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }
        #endregion

        private string CreateEmployeeInfoStr(Data.Entities.Employee employee)
        {
            var info = new StringBuilder();

            info.Append("Id = ");
            info.Append(employee.Id);

            info.Append(", FirstName = ");
            info.Append(employee.FirstName);

            info.Append(", LastName = ");
            info.Append(employee.LastName);

            info.Append(", SalaryPerHour = ");
            info.Append(employee.SalaryPerHous);

            return info.ToString();
        }
    }
}
