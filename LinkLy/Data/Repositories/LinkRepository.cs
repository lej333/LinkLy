using LinkLy.Models.DataModels;
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
        /// Generates a query based on current logged in user and search string, descending sorted by last click or creation date (depends on its null value)
        /// This query will be executed by paginatedlist helper class
        /// </summary>
        /// <param name="search"></param>
        public IQueryable<Link> GetQuery(string search = "")
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var links = from l in _db.Links.Include(l => l.Clicks).Where(l => l.UserId == userId).OrderByDescending(l => l.LastClick == null ? l.CreationDate : l.LastClick) 
                        select l;

            if (!String.IsNullOrEmpty(search))
            {
                links = links.Where(l => l.Name.Contains(search) || l.Uri.Contains(search));
            }
            return links.AsNoTracking();
        }

        /// <summary>
        /// Override the default Get function to add Clicks to the object
        /// </summary>
        /// <param name="id"></param>
        public override async Task<Link> Get(int id)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Link link = await _db.Links.Include(l => l.Clicks).FirstOrDefaultAsync(l => l.Id == id);
            if (link != null && link.UserId != userId)
            {
                return null;
            };
            return link;
        }
    }
}