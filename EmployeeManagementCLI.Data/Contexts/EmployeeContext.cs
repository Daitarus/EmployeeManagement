using EmployeeManagementCLI.Data.Contexts.Interfaces;
using EmployeeManagementCLI.Data.Entities;
using EmployeeManagementCLI.Data.Handlers.Interfaces;
using EmployeeManagementCLI.Data.Models;

namespace EmployeeManagementCLI.Data.Context
{
    public class EmployeeContext : IContext<Employee>
    {
        private readonly IRecorderHandler _recorderService;
        private Employees _employees;
        private int _changeCounter = 1;

        public EmployeeContext(IRecorderHandler recorderService)
        {
            _recorderService = recorderService;
            _employees = _recorderService.ReadModel<Employees>() ?? new Employees();
        }

        public Employee AddEntity(Employee entity)
        {
            var maxId = _employees.EmployeesList.Max(e => e.Id);
            entity.Id = maxId++;

            _employees.EmployeesList.Add(entity);
            _changeCounter++;

            return entity;
        }

        public void DeleteEntity(int id)
        {
            var deleteEntity = _employees.EmployeesList.Where(e => e.Id == id).FirstOrDefault();

            if (deleteEntity != null)
            {
                _employees.EmployeesList.Remove(deleteEntity);
                _changeCounter++;
            }
        }

        public Employee? GetEntity(int id)
        {
            return _employees.EmployeesList.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAllEntities()
        {
            return _employees.EmployeesList;
        }

        public Employee? UpdateEntity(Employee entity)
        {
            var updatableEntity = _employees.EmployeesList.Where(e => e.Id == entity.Id).FirstOrDefault();

            if (updatableEntity != null)
            {
                var сopiesQuantity = CopyModelFields(updatableEntity, entity);

                if (сopiesQuantity > 0) 
                    _changeCounter++;

                return updatableEntity;
            }

            return null;
        }

        public int SaveChanges()
        {
            _recorderService.WriteModel(_employees);

            var changeCounter = _changeCounter;
            _changeCounter = 0;
            return changeCounter;
        }

        public async Task<int> SaveChangesAsync()
        {
            await _recorderService.WriteModelAsync(_employees);

            var changeCounter = _changeCounter;
            _changeCounter = 0;
            return changeCounter;
        }

        private int CopyModelFields(Employee originalEmployee, Employee newEmployee)
        {
            var сopiesQuantity = 0;

            if(newEmployee.FirstName != null && newEmployee.FirstName != originalEmployee.FirstName)
            {
                originalEmployee.FirstName = newEmployee.FirstName;
                сopiesQuantity++;
            }

            if (newEmployee.LastName != null && newEmployee.LastName != originalEmployee.LastName)
            {
                originalEmployee.LastName = newEmployee.LastName;
                сopiesQuantity++;
            }

            if (newEmployee.SalaryPerHous != null && newEmployee.SalaryPerHous != originalEmployee.SalaryPerHous)
            {
                originalEmployee.SalaryPerHous = newEmployee.SalaryPerHous;
                сopiesQuantity++;
            }

            return сopiesQuantity;
        }
    }
}
