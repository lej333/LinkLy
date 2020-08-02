using LinkLy.Models;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;

namespace Linkly.Data.Repositories
{
    public class LinkRepository : BaseUserRepository<Link, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LinkRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) : base(db, httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Generates a list with all links created by currently loggedin user, descending sorted by last click
        /// With search and paging possibility
        /// </summary>
        /// <param name="userId">Possibility to get list of other user instead of the current loggedin user</param>
        public async Task<List<Link>> GetPaged(string search = "")
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var links = from l in _db.Links.Include(l => l.Clicks).Where(l => l.UserId == userId).OrderByDescending(l => l.LastClick) 
                        select l;

            if (!String.IsNullOrEmpty(search))
            {
                links = links.Where(l => l.Name.Contains(search) || l.Uri.Contains(search));
            }
            return await links.ToListAsync();
        }
    }
}