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
                             ReleaseDate=DateTime.Parse("1989-1-11"),  
                             Genre="Romantic Comedy", 
                             Rating="R", 
                             Price=7.00M}, 
 
                 new Movie { Title = "Ghostbusters 2",  
                             ReleaseDate=DateTime.Parse("1986-2-23"),  
                             Genre="Comedy", 
                             Rating="R", 
                             Price=9.00M},  
             };

            movies.ForEach(d => context.Movies.Add(d));

        }
    }
}