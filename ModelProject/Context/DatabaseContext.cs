using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelProject.Model;

namespace ModelProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment; 
        public DbSet <Like> Likes { get; set; } 

        public DbSet <Follow> Followed { get; set; } 

        public DbSet <Watchlist> Watchlists { get; set; } 

        public DbSet <DigitalModel> DigitalModels { get; set; } 

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }

    
     }
}
