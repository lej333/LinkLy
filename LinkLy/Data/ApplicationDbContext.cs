using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LinkLy.Models;

namespace LinkLy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Click> Clicks { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        public DbSet<Domain> Domains { get; set; }
    }
}
