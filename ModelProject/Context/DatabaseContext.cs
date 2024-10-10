using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelProject.Model;

namespace ModelProject.Context
{
    public class DatabaseContext : IdentityDbContext<Users>
    {

        private IWebHostEnvironment _environment; 
        public DbSet<Watchlist> Whatchlists { get; set; } 

        public DbSet<Like> Likes { get; set; }

        public DbSet<Followed> Followers { get; set; }

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
            optionbuilder.UseSqlite($"Data Source={folder}/ModelProject.db");
        }
    }
}
