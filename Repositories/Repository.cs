using BookHub.DataProvider;
using BookHub.Models;

namespace BookHub.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly BookContext _dbContext;

        public Repository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetEntities()
        {
            return _dbContext.GetEntities<TEntity>();
        }

        public async Task<TEntity> GetEntityByID(Guid entityId)
        {
            return await _dbContext.FindAsync(typeof(TEntity), entityId) as TEntity;
        }

        /// <summary/>
        public async Task<TEntity> InsertEntity(TEntity entity, bool autoSave = true)
        {
            entity.Id = Guid.NewGuid();
            _dbContext.Add(entity);

            if (autoSave)
                await Save();

            return entity;
        }

        /// <summary/>
        public async Task UpdateEntity(TEntity entity, bool autoSave = true)
        {
            _dbContext.Update(entity);

            if (autoSave)
                await Save();
        }

        /// <summary/>
        public async Task DeleteEntity(Guid entityId, bool autoSave = true)
        {
            var entity = _dbContext.Find(typeof(TEntity), entityId);
            _dbContext.Remove(entity);

            if (autoSave)
                await Save();
        }

        /// <summary/>
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
