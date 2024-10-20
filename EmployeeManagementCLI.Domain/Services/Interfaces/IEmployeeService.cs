﻿using EmployeeManagementCLI.Domain.Models;

namespace EmployeeManagementCLI.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Message AddEmployee(Employee employee);

        public Message UpdateEmployee(Employee employee);

        public Message GetEmployee(int id);

        public Message DeleteEmployee(int id);

        public Message GetAllEmployees();
    }
}
