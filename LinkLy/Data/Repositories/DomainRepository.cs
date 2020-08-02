using LinkLy.Models;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using LinkLy.Helpers;

namespace Linkly.Data.Repositories
{
    public class DomainRepository : BaseUserRepository<UserSetting, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Defaults _defaults;

        public DomainRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, Defaults defaults) : base(db, httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _defaults = defaults;
        }

        public async Task<List<Domain>> GetByUser(string userId = "")
        {
            if (userId == "")
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

            var query = _db.Domains.Where(s => s.UserId == userId);
            List<Domain> domains = await query.ToListAsync();
            if (domains == null || domains.Count() == 0) {
                Domain domain = new Domain()
                {
                    UserId = userId,
                    Name = _defaults.Domain
                };
                _db.Domains.Add(domain);
                await _db.SaveChangesAsync();
                domains = await query.ToListAsync();
            };
            return domains;
        }

    }
}