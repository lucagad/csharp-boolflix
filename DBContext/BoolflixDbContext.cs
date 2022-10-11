using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Models;

namespace csharp_boolflix.DBContext;

public class BoolflixDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<TVSeries> TvSeries { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<MediaInfo> MediaInfos { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Feature> Features { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Initial Catalog=db_boolflix;Persist Security Info=True;User ID=sa;Password=NET2022!");
        }
    }
