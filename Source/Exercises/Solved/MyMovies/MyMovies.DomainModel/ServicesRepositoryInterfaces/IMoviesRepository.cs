using System.Collections.Generic;
using MyMovies.Rep;
using MyMovies.Repository;

namespace MyMovies.DomainModel.ServicesRepositoryInterfaces
{
    public interface IMoviesRepository : IRepository<Movie, int>
    {
        ICollection<Movie> SearchByTitle(string title);
    }
}