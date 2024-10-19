using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Message Create(EmployeeDto employeeDto);

        public Message UpdateEmployee(EmployeeDto employeeDto);

        public Message GetEmployee(int id);

        public Message Delete(int id);

        public Message GetAll();
    }
}
