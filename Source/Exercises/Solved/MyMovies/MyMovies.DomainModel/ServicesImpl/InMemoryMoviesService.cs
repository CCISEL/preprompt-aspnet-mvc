using System;
using System.Collections.Generic;
using MyMovies.DomainModel.Services;

namespace MyMovies.DomainModel.ServicesImpl
{
    public class InMemoryMoviesService : IMoviesService
    {
        public ICollection<Movie> GetAllMovies()
        {
            return new List<Movie>()
                       {
                           new Movie()
                               {
                                   ID = 1,
                                   Title = "Traseiros em brasa",
                                   Genre = "Quentinho",
                               },
                           new Movie()
                               {
                                   ID = 1,
                                   Title = "Coelhinhas na cama",
                                   Genre = "Morninho",
                               }
                       };
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
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