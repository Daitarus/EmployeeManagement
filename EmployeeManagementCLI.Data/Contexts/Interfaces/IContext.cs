using EmployeeManagementCLI.Data.Entities.Base;

namespace EmployeeManagementCLI.Data.Contexts.Interfaces
{
    public interface IContext<T> where T : Entity
    {
        public void AddEntity(T entity);

        public void UpdateEntity(T entity);

        public T GetEntity(int id);

        public IEnumerable<T> GetAllEntities();

        public void DeleteEntity(int id);

        public void SaveChanges();

        public Task SaveChangesAsync();
    }
}
