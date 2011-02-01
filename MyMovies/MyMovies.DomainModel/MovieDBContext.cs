using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace MyMovies.DomainModel
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(p => p.Price).HasPrecision(18, 2);
        }

    }
}