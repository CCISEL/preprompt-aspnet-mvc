using System;
using System.Collections.Generic;
using System.Data.Entity.Database;
using MyMovies.DomainModel;

namespace MyMovies.WebApp.Models
{
    public class MoviesInitializer : DropCreateDatabaseIfModelChanges<MovieDBContext>
    {
        protected override void Seed(MovieDBContext context)
        {

            var movies = new List<Movie> { 
 
                 new Movie { Title = "When Harry Met Sally",  
                             Genre="Romantic Comedy", 
                 }, 
 
                 new Movie { Title = "Ghostbusters 2",  
                             Genre="Comedy", 
                 },  
             };

            movies.ForEach(d => context.Movies.Add(d));

        }
    }
}