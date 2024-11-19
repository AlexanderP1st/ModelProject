using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ModelProject.Model;
using System;

namespace ModelProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        private IWebHostEnvironment _environment;

        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Followed { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<DigitalModel> DigitalModels { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            optionbuilder.UseSqlite($"Data Source={folder}/database.db");
        }
    }
}