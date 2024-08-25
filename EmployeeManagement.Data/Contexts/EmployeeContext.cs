using EmployeeManagement.Data.Contexts.Interfaces;
using EmployeeManagement.Data.Entities;
using EmployeeManagement.Data.Handlers.Interfaces;
using EmployeeManagement.Data.Models;

namespace EmployeeManagement.Data.Context
{
    public class EmployeeContext : IContext<Employee>
    {
        private readonly IRecorderHandler _recorderService;
        private Employees _employees;

        public EmployeeContext(IRecorderHandler recorderService)
        {
            _recorderService = recorderService;
            _employees = _recorderService.ReadModel<Employees>() ?? new Employees();
        }

        public Employee AddEntity(Employee entity)
        {
            var employee = new Employee(entity);

            if (_employees.EmployeesList.Count > 0)
            {
                var maxId = _employees.EmployeesList.Max(e => e.Id);
                employee.Id = ++maxId;
            }
            else
            {
                employee.Id = 1;
            }
            _employees.EmployeesList.Add(employee);

            return employee;
        }

        public bool DeleteEntity(int id)
        {
            var deleteEntity = _employees.EmployeesList.Where(e => e.Id == id).FirstOrDefault();

            if (deleteEntity != null)
            {
                _employees.EmployeesList.Remove(deleteEntity);
                return true;
            }

            return false;
        }

        public Employee? GetEntity(int id)
        {
            return _employees.EmployeesList.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAllEntities()
        {
            return _employees.EmployeesList;
        }

        //public Employee? UpdateEntity(Employee entity)
        //{
        //    var updatableEntity = _employees.EmployeesList.Where(e => e.Id == entity.Id).FirstOrDefault();

        //    if (updatableEntity != null)
        //    {
        //        var сopiesQuantity = CopyModelFields(updatableEntity, entity);

        //        return updatableEntity;
        //    }

        //    return null;
        //}

        public void SaveChanges()
        {
            _recorderService.WriteModel(_employees);
        }

        public async Task SaveChangesAsync()
        {
            await _recorderService.WriteModelAsync(_employees);
        }

        //private int CopyModelFields(Employee originalEmployee, Employee newEmployee)
        //{
        //    var сopiesQuantity = 0;

        //    if(newEmployee.FirstName != null && newEmployee.FirstName != originalEmployee.FirstName)
        //    {
        //        originalEmployee.FirstName = newEmployee.FirstName;
        //        сopiesQuantity++;
        //    }

        //    if (newEmployee.LastName != null && newEmployee.LastName != originalEmployee.LastName)
        //    {
        //        originalEmployee.LastName = newEmployee.LastName;
        //        сopiesQuantity++;
        //    }

        //    if (newEmployee.SalaryPerHous != null && newEmployee.SalaryPerHous != originalEmployee.SalaryPerHous)
        //    {
        //        originalEmployee.SalaryPerHous = newEmployee.SalaryPerHous;
        //        сopiesQuantity++;
        //    }

        //    return сopiesQuantity;
        //}
    }
}
