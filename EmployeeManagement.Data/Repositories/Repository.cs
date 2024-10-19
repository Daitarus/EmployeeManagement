using EmployeeManagement.Domain.Entities.Interfaces;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Data.Contexts.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Data.Repositories
{
    public abstract class Repository<TEntity, T> : IRepository<TEntity, T> where TEntity : class, IEntity<T> where T : struct, IIncrementOperators<T>
    {
        private readonly IContext<TEntity, T> _context;

        public Repository(IContext<TEntity, T> context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            entity = _context.AddEntity(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void CreateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.AddEntity(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.DeleteEntity(entity.Id);
            _context.SaveChanges();
        }

        public void DeleteById(T id)
        {
            _context.DeleteEntity(id);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                _context.DeleteEntity(entity.Id);
            }
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.GetAllEntities();
        }

        public TEntity? GetById(T id)
        {
            return _context.GetEntity(id);
        }

        public void Update(TEntity entity)
        {
            var oldEntity = _context.GetEntity(entity.Id);

            if (oldEntity == null) throw new InvalidOperationException($"");


        }
    }
}
