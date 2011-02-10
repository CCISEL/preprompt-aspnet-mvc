using System.Linq;

namespace MyMovies.DomainModel.ServicesRepositoryInterfaces {
    using Rep;

    public interface IMoviesRepository : IRepository<Movie, int> {
        Movie SearchByTitle(string title);
        IQueryable<string> GetGenres();
    }
}