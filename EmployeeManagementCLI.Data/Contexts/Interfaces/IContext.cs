using EmployeeManagementCLI.Data.Entities.Base;

namespace EmployeeManagementCLI.Data.Contexts.Interfaces
{
    public interface IContext<T> where T : Entity
    {
        public T AddEntity(T entity);

        public T? GetEntity(int id);

        public IEnumerable<T> GetAllEntities();

        public bool DeleteEntity(int id);

        public void SaveChanges();

        public Task SaveChangesAsync();
    }
}
