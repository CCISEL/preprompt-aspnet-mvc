using System;
using System.Collections.Generic;
using System.Linq;
using MyMovies.DomainModel.Services;

namespace MyMovies.DomainModel.ServicesImpl
{
    public class EFMoviesService : IMoviesService, IDisposable
    {
        private readonly MovieDBContext _movieDbContext;

        public EFMoviesService(MovieDBContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public ICollection<Movie> GetAllMovies()
        {
            return _movieDbContext.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return _movieDbContext.Movies.Find(id);
        }

        public Movie GetWithComments(int id)
        {
            return _movieDbContext.Movies.Find(id);
        }

        public void Add(Movie newMovie)
        {
            _movieDbContext.Movies.Add(newMovie);
            _movieDbContext.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _movieDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Movie m = _movieDbContext.Movies.Find(id);
            if(m == null)
            {
                throw new ArgumentException(String.Format("Movie with id {0} could not be found", id), "id");
            }

            _movieDbContext.Movies.Remove(m);
            _movieDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _movieDbContext.Dispose();
        }
    }
}