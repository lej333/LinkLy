﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkLy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkLy.Data.BaseRepositories
{
    /// <summary>
    /// Abstract class with basic functions to run CRUD operations on the database
    /// Implemented according to Repositories Pattern
    /// Automatically fill up default properties before proceed to the database
    /// Use this class when implenting a repository without relation to ASP.NET users
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDb"></typeparam>
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
        public virtual async Task<TEntity> Add(TEntity entity)
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
        public virtual async Task<TEntity> Delete(int id)
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
        public virtual async Task<TEntity> Get(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Gets a list with entities.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Updates one entity to database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
