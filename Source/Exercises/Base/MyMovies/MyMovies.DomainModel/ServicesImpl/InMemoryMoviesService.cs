using System;
using System.Collections.Generic;
using MyMovies.DomainModel.Services;

namespace MyMovies.DomainModel.ServicesImpl
{
    public class InMemoryMoviesService : IMoviesService
    {
        public ICollection<Movie> GetAllMovies()
        {
            var movies = new List<Movie>
                             {

                                 new Movie
                                     {
                                         ID = 1,
                                         Title = "When Harry Met Sally1",
                                         Genre = "Romantic Comedy",
                                         Year = 2004,
                                         Comments = new List<Comment>()
                                     },

                                 new Movie
                                     {
                                         ID = 2,
                                         Title = "Ghostbusters 2",
                                         Genre = "Comedy",
                                         Year = 2002,
                                         Comments = new List<Comment>()
                                     },
                             };

            var comments = new List<Comment>
                               {
                                   new Comment
                                       {
                                           Description = "Description 1",
                                           Rating = 3,
                                           Movie = movies[0]
                                       },
                                   new Comment
                                       {
                                           Description = "Description 2",
                                           Rating = 4,
                                           Movie = movies[0]
                                       },

                                   new Comment
                                       {
                                           Description = "Description 3",
                                           Rating = 5,
                                           Movie = movies[1]
                                       },
                                       new Comment
                                       {
                                           Description = "Description 4",
                                           Rating = 4,
                                           Movie = movies[1]
                                       },

                               };
            return movies;
        }

        public Movie Get(int id)
        {
            foreach (Movie m in GetAllMovies()) {
                if (m.ID == id) return m;
            }
            return null;
        }

        public Movie GetWithComments(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Search(string title)
        {
            throw new NotImplementedException();
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}