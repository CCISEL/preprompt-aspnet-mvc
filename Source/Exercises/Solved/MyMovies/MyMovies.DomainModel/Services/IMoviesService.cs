using System;
using System.Collections.Generic;

namespace MyMovies.DomainModel.Services
{
    public interface IMoviesService : IDisposable
    {
        ICollection<Movie> GetAllMovies();
        Movie Get(int id);
        void Add(Movie newMovie);
        void Update(Movie movie);
        void Delete(int id);
        Movie Search(string title);
        ICollection<string> GetGenres();
    }
}