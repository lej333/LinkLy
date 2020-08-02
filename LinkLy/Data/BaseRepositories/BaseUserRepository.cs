using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LinkLy.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinkLy.Data.BaseRepositories
{
    public abstract class BaseUserRepository<TUserEntity, TDb> : IBaseUserRepository<TUserEntity>
        where TUserEntity : class, IUserEntity
        where TDb : ApplicationDbContext
    {
        private readonly TDb _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseUserRepository(TDb db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Adds one new entity to the database.
        /// Adds id of the current logged in user.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TUserEntity> Add(TUserEntity entity)
        {
            entity.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            entity.CreationDate = DateTime.Now;
            _db.Set<TUserEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes one entity from database based on its Id.
        /// Validation on ownership by the current logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TUserEntity> Delete(int id)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var entity = await _db.Set<TUserEntity>().FindAsync(id);
            if (entity == null || entity.UserId != userId)
            {
                return null;
            }

            _db.Set<TUserEntity>().Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Gets one entity from database based on its Id.
        /// Validation on ownership by the current logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TUserEntity> Get(int id)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            TUserEntity entity = await _db.Set<TUserEntity>().FindAsync(id);
            if (entity != null && entity.UserId != userId) {
                return null;
            };
            return entity;
        }

        /// <summary>
        /// Gets a list with entities owned by the current logged in user.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TUserEntity>> GetAll()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _db.Set<TUserEntity>().Where(e => e.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Updates one entity to database.
        /// Validation on ownership by the current logged user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TUserEntity> Update(TUserEntity entity)
        {
            TUserEntity check = await Get(entity.Id);
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (check.UserId != userId) {
                return entity;
            };
            entity.ModifiedDate = DateTime.Now;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
