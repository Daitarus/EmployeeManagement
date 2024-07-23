using EmployeeManagementCLI.Entities.Base;

namespace EmployeeManagementCLI.Services.Interfaces
{
    public interface IRepositoryService<T> where T : Entity
    {
        public void AddEntity(T entity);

        public void UpdateEntity(T entity);

        public T GetEntity(int id);

        public void DeleteEntity(int id);
    }
}
