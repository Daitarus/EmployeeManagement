using EmployeeManagement.Data.Contexts.Interfaces;
using EmployeeManagement.Data.Handlers.Interfaces;
using EmployeeManagement.Data.Models;
using EmployeeManagement.Domain.Entities.Interfaces;
using System.Numerics;

namespace EmployeeManagement.Data.Context
{
    public class Context<TEntity, T> : IContext<TEntity, T> where TEntity : class, IEntity<T> where T : struct, IIncrementOperators<T>
    {
        private readonly IRecorderHandler _recorderHandler;
        private EntityCollection<TEntity, T> _entityCollection;

        public Context(IRecorderHandler recorderHandler)
        {
            _recorderHandler = recorderHandler;
            _entityCollection = _recorderHandler.ReadModel<EntityCollection<TEntity, T>>() ?? new EntityCollection<TEntity, T>();
        }

        public TEntity AddEntity(TEntity entity)
        {
            if (_entityCollection.Entities.Count > 0)
            {
                var maxId = _entityCollection.Entities.Max(e => e.Id);
                entity.Id = ++maxId;
            }
            else
            {
                entity.Id = default;
            }
            _entityCollection.Entities.Add(entity);

            return entity;
        }

        public void DeleteEntity(T id)
        {
            var deleteEntity = _entityCollection.Entities.Where(e => e.Id.Equals(id)).FirstOrDefault();

            if (deleteEntity == null) throw new InvalidOperationException($"entity whith Id = {id} not found");

            _entityCollection.Entities.Remove(deleteEntity);
        }

        public TEntity? GetEntity(T id)
        {
            return _entityCollection.Entities.Where(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAllEntities()
        {
            return _entityCollection.Entities;
        }

        public void SaveChanges()
        {
            _recorderHandler.WriteModel(_entityCollection);
        }
    }
}
