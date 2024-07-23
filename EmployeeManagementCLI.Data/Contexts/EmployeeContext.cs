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

        public EmployeeContext(IRecorderHandler recorderService)
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
        }

        public void DeleteEntity(int id)
        {
            var deleteEntity = _employees.EmployeesList.Where(e => e.Id == id).First();
            _employees.EmployeesList.Remove(deleteEntity);
        }

        public Employee GetEntity(int id)
        {
            return _employees.EmployeesList.Where(e => e.Id == id).First();
        }

        public IEnumerable<Employee> GetAllEntities()
        {
            return _employees.EmployeesList;
        }

        public void UpdateEntity(Employee entity)
        {
            var updatableEntity = _employees.EmployeesList.Where(e => e.Id == entity.Id).First();
            updatableEntity = entity;
        }

        public void SaveChanges()
        {
            _recorderService.WriteModel(_employees);
        }

        public async Task SaveChangesAsync()
        {
            await _recorderService.WriteModelAsync(_employees);
        }
    }
}
