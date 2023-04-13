using BookHub.Models;

namespace BookHub.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        IQueryable<TEntity> GetEntities();

        /// <summary>
        /// Get entity by ID
        /// </summary>
        Task<TEntity> GetEntityByID(Guid entityId);

        /// <summary>
        /// To insert new entity to the DB
        /// </summary>
        /// <param name="autoSave">If it's true, it will save automatically</param>
        Task<TEntity> InsertEntity(TEntity entity, bool autoSave = true);

        /// <summary>
        /// To update exists entity
        /// </summary>
        /// <param name="autoSave">If it's true, it will save automatically</param>
        Task UpdateEntity(TEntity entity, bool autoSave = true);

        /// <summary>
        /// To delete entity
        /// </summary>
        /// <param name="autoSave">If it's true, it will save automatically</param>
        Task DeleteEntity(Guid entityId, bool autoSave = true);

        /// <summary>
        /// To save all changes
        /// </summary>
        Task Save();
    }
}
