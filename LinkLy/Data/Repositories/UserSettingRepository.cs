using LinkLy.Models.DataModels;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Linkly.Data.Repositories
{
    public class UserSettingRepository : BaseUserRepository<UserSetting, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSettingRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) : base(db, httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Retrieves user setting for the current logged in user
        /// Adds a new user setting when not created before (with defaults)
        /// </summary>
        /// <returns></returns>
        public async Task<UserSetting> GetByUserWithDefault()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            UserSetting userSetting = await _db.UserSettings.FirstOrDefaultAsync(s => s.UserId == userId);
            if (userSetting == null)
            {
                userSetting = new UserSetting();
                _db.UserSettings.Add(userSetting);
                await _db.SaveChangesAsync();
                userSetting = await _db.UserSettings.FirstOrDefaultAsync(s => s.UserId == userId);
            }
            return userSetting;
        }

    }
}