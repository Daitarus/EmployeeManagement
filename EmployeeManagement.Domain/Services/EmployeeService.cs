using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Repository;
using EmployeeManagement.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EmployeeManagement.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService>? _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService>? logger = null)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        #region Service action
        public Message Create(EmployeeDto employeeDto)
        {
            if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));

            if(string.IsNullOrEmpty(employeeDto.FirstName) || string.IsNullOrEmpty(employeeDto.LastName) || employeeDto.SalaryPerHour == null)
            {
                _logger?.LogWarning($"[{nameof(Create)}]: Warning: not all data is filled for action!");
                return new Message(ActionStatus.NotSuccess, $"Warning: not all data is filled for action");
            }

            try
            {
                var salaryDecimal = (decimal)employeeDto.SalaryPerHour;
                if (salaryDecimal < 0)
                {
                    _logger?.LogWarning($"[{nameof(Create)}]: Warning: Salary should be more than 0!");
                    return new Message(ActionStatus.NotSuccess, $"Warning: Salary should be more than 0");
                }

                var employee = new Employee()
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    SalaryPerHour = salaryDecimal
                };

                employee = _employeeRepository.Create(employee);

                _logger?.LogInformation($"[{nameof(Create)}][Id = {employee.Id}]: Success!");
                return new Message(ActionStatus.Success, $"EmployeeDto was added (Id = {employee.Id})");
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(Create)}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message Delete(int id)
        {
            try
            {
                _employeeRepository.DeleteById(id);
                _logger?.LogInformation($"[{nameof(Delete)}][Id = {id}]: Success!");
                return new Message(ActionStatus.Success, $"EmployeeDto with Id = {id} was deleted!");
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(Delete)}][Id = {id}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message GetAll()
        {
            try
            {
                var employees = _employeeRepository.GetAll();

                if (employees == null || employees?.Count == 0)
                {
                    _logger?.LogWarning($"[{nameof(GetAll)}]: Warning: no data available!");
                    return new Message(ActionStatus.NotSuccess, "Warning: no data available!");
                }
                else
                {
                    var resultText = new StringBuilder();
                    foreach (var employee in employees)
                    {
                        resultText.AppendLine(CreateEmployeeInfoStr(employee));
                    }

                    _logger?.LogInformation($"[{nameof(GetAll)}]: Success!");
                    return new Message(ActionStatus.Success, resultText.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(GetAll)}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }

        public Message GetEmployee(int id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);

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

        public Message UpdateEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null) throw new ArgumentNullException(nameof(employeeDto));

            try
            {
                var employee = _employeeRepository.GetById(employeeDto.Id);

                if (employee != null)
                {
                    bool wasChanges = false;

                    if (!string.IsNullOrEmpty(employeeDto.FirstName))
                    {
                        wasChanges = true;
                        employee.FirstName = employeeDto.FirstName;
                    }

                    if (!string.IsNullOrEmpty(employeeDto.LastName))
                    {
                        wasChanges = true;
                        employee.LastName = employeeDto.LastName;
                    }

                    if (employeeDto.SalaryPerHour != null)
                    {
                        var salaryDecimal = (decimal)employeeDto.SalaryPerHour;
                        if (salaryDecimal < 0)
                        {
                            _logger?.LogWarning($"[{nameof(Create)}]: Warning: Salary should be more than 0!");
                            return new Message(ActionStatus.NotSuccess, $"Warning: Salary should be more than 0");
                        }
                        else
                        {
                            wasChanges = true;
                            employee.SalaryPerHour = salaryDecimal;
                        }
                    }

                    if (wasChanges)
                    {
                        _employeeRepository.Update(employee);

                        _logger?.LogInformation($"[{nameof(UpdateEmployee)}][Id = {employee.Id}]: Success!");
                        return new Message(ActionStatus.Success, $"EmployeeDto with Id = {employee.Id} was updated!");
                    }
                    else
                    {
                        _logger?.LogWarning($"[{nameof(UpdateEmployee)}][Id = {employee.Id}]: Warning: no data available!");
                        return new Message(ActionStatus.NotSuccess, $"Warning: no data available");
                    }
                }
                else
                {
                    _logger?.LogWarning($"[{nameof(UpdateEmployee)}][Id = {employeeDto.Id}]: Warning: no updated data!");
                    return new Message(ActionStatus.NotSuccess, $"Warning: no updated data");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError($"[{nameof(UpdateEmployee)}][Id = {employeeDto.Id}]: {ex.Message}", ex);
                return new Message(ActionStatus.Error, "Error: action failed!");
            }
        }
        #endregion

        private string CreateEmployeeInfoStr(Employee employee)
        {
            var info = new StringBuilder();

            info.Append("Id = ");
            info.Append(employee.Id);

            info.Append(", FirstName = ");
            info.Append(employee.FirstName);

            info.Append(", LastName = ");
            info.Append(employee.LastName);

            info.Append(", SalaryPerHour = ");
            info.Append(employee.SalaryPerHour);

            return info.ToString();
        }
    }
}
