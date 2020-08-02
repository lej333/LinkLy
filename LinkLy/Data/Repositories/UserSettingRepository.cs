using LinkLy.Models;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using LinkLy.Interfaces;
using LinkLy.Helpers;

namespace Linkly.Data.Repositories
{
    public class UserSettingRepository : BaseUserRepository<UserSetting, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDefaults _defaults;

        public UserSettingRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, Defaults defaults) : base(db, httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _defaults = defaults;
        }

        public async Task<UserSetting> GetByUser(string userId = "")
        {
            if (userId == "")
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            UserSetting userSetting = await _db.UserSettings.FirstOrDefaultAsync(s => s.UserId == userId);
            if (userSetting == null)
            {
                userSetting = new UserSetting()
                {
                    UserId = userId
                };
                _db.UserSettings.Add(userSetting);
                await _db.SaveChangesAsync();
                userSetting = await _db.UserSettings.FirstOrDefaultAsync(s => s.UserId == userId);
            }
            return userSetting;
        }

    }
}