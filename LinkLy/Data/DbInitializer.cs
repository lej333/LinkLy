using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LinkLy.Data
{
    /// <summary>
    /// DB initial seeder, seeds with data ie first admin user to be sure new customer can start with fresh installed database
    /// </summary>
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager) {
            _db = db;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            if (_db.Users.Count() > 0) return;

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "info@swalbe.nl",
                Email = "info@swalbe.nl",
                EmailConfirmed = true
            }, "Admin1234*").GetAwaiter().GetResult();
        }
    }
}
