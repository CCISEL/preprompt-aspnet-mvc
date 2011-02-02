namespace MyMovies.DomainModel.ServicesRepositoryInterfaces {
    using System.Collections.Generic;
    using Rep;

    public interface IMoviesRepository : IRepository<Movie, int> {
        Movie SearchByTitle(string title);
    }
}