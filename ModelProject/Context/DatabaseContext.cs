using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelProject.Model;
using System;

namespace ModelProject.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Followed { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<DigitalModel> DigitalModels { get; set; }
        
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");

        }
    }
}
