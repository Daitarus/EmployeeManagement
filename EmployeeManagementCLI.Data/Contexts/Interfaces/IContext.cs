using EmployeeManagementCLI.Data.Entities.Base;

namespace EmployeeManagementCLI.Data.Contexts.Interfaces
{
    public interface IContext<T> where T : Entity
    {
        public T AddEntity(T entity);

        public T? UpdateEntity(T entity);

        public T? GetEntity(int id);

        public IEnumerable<T> GetAllEntities();

        public void DeleteEntity(int id);

        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}
