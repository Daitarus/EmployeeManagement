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

        public void AddEntity(Employee entity)
        {
            _employees.EmployeesList.Add(entity);
        }

        public void DeleteEntity(int id)
        {
            var deleteEntity = _employees.EmployeesList.Where(e => e.Id == id).First();
            _employees.EmployeesList.Remove(deleteEntity);
        }

        public Employee? GetEntity(int id)
        {
            return _employees.EmployeesList.Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAllEntities()
        {
            return _employees.EmployeesList;
        }

        public void UpdateEntity(Employee entity)
        {
            var updatableEntity = _employees.EmployeesList.Where(e => e.Id == entity.Id).FirstOrDefault();

            if (updatableEntity != null)
            {
                updatableEntity = entity;
            }
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
