using LinkLy.Models.DataModels;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using LinkLy.Helpers;

namespace Linkly.Data.Repositories
{
    public class DomainRepository : BaseUserRepository<Domain, ApplicationDbContext>
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

        /// <summary>
        /// This will retrieve a list with all registered domains for the current logged in user
        /// Adds a new default domain when the current logged in user doesn't have any domain registered
        /// </summary>
        /// <returns></returns>
        public async Task<List<Domain>> GetAllWithDefault()
        {
            List<Domain> domains = await GetAll();
            if (domains == null || domains.Count() == 0) {
                string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                Domain domain = new Domain()
                {
                    UserId = userId,
                    Name = _defaults.Domain
                };
                _db.Domains.Add(domain);
                await _db.SaveChangesAsync();
                domains = await GetAll();
            };
            return domains;
        }

    }
}