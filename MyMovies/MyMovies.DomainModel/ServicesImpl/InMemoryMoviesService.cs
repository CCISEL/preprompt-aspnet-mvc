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
                                   Price = 999.99M,
                                   ReleaseDate = DateTime.Parse("1-1-1980")


                               },
                           new Movie()
                               {
                                   ID = 1,
                                   Title = "Coelhinhas na cama",
                                   Genre = "Morninho",
                                   Price = 699.99M,
                                   ReleaseDate = DateTime.Parse("1-1-1985")
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
    }
}