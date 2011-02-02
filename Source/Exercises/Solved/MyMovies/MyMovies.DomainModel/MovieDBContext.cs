
namespace MyMovies.DomainModel
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The EF <see cref="DbContext"/> to <see cref="Movie"/> type.
    /// </summary>
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>().Property(p => p.Price).HasPrecision(18, 2);
        }

    }
}