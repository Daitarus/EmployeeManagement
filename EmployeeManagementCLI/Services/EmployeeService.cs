using EmployeeManagementCLI.Entities;
using EmployeeManagementCLI.Models;
using EmployeeManagementCLI.Services.Interfaces;

namespace EmployeeManagementCLI.Services
{
    public class EmployeeService : IRepositoryService<Employee>
    {
        private readonly IRecorderService _recorderService;
        private Employees _employees;

        public EmployeeService(IRecorderService recorderService)
        {
            _recorderService = recorderService;
            _employees = _recorderService.ReadModel<Employees>() ?? new Employees();
        }

        public Employees CreateMockEmployees()
        {
            var e1 = new Employee(1, "Name1", "LastName1", 3.1m);
            var e2 = new Employee(2, "Name2", "LastName2", 3.2m);
            var e3 = new Employee(3, "Name3", "LastName3", 3.3m);
            var e4 = new Employee(4, "Name4", "LastName4", 3.4m);
            var e5 = new Employee(5, "Name5", "LastName5", 3.5m);

            return new Employees()
            {
                EmployeesList = [e1, e2, e3, e4, e5]
            };
        }

        public void AddEntity(Employee entity)
        {
            _employees.EmployeesList.Add(entity);
            SaveChanges();
        }

        public void DeleteEntity(int id)
        {
            var deleteEntity = _employees.EmployeesList.Where(e => e.Id == id).First();
            _employees.EmployeesList.Remove(deleteEntity);
            SaveChanges();
        }

        public Employee GetEntity(int id)
        {
            return _employees.EmployeesList.Where(e => e.Id == id).First();
        }

        public void UpdateEntity(Employee entity)
        {
            var updatableEntity = _employees.EmployeesList.Where(e => e.Id == entity.Id).First();
            updatableEntity = entity;
            SaveChanges();
        }

        private void SaveChanges()
        {
            _recorderService.WriteModel(_employees);
        }

        private async Task SaveChangesAsync()
        {
            await _recorderService.WriteModelAsync(_employees);
        }
    }
}
