using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkLy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkLy.Data.BaseRepositories
{
    public abstract class BaseRepository<TEntity, TDb> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TDb : ApplicationDbContext
    {
        private readonly TDb _db;

        public BaseRepository(TDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Adds one new entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes one entity from database based on its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> Delete(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Gets one entity from database based on its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Gets a list with entities.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAll()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Updates one entity to database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
