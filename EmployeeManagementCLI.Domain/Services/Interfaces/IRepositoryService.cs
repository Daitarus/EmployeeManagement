using EmployeeManagementCLI.Domain.Entities.Base;

namespace EmployeeManagementCLI.Domain.Services.Interfaces
{
    public interface IRepositoryService<T> where T : Entity
    {
        public void AddEntity(T entity);

        public void UpdateEntity(T entity);

        public T GetEntity(int id);

        public void DeleteEntity(int id);
    }
}
