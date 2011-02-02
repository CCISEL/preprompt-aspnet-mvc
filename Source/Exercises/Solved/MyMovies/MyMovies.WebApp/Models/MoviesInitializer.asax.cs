namespace MyMovies.WebApp.Models {
    using System.Collections.Generic;
    using System.Data.Entity.Database;
    using DomainModel;

    public class MoviesInitializer : DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {

            var movies = new List<Movie> { 
 
                 new Movie { Title = "When Harry Met Sally",  
                             Genre="Romantic Comedy", 
                             Year = 2004
                 }, 
 
                 new Movie { Title = "Ghostbusters 2",  
                             Genre="Comedy", 
                             Year = 2002
                 },  
             };

            movies.ForEach(d => context.Movies.Add(d));

        }
    }
}