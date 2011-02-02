using System.Linq;
using MyMovies.DomainModel.ServicesImpl;

namespace MyMovies.WebApp.Models {
    using System.Collections.Generic;
    using System.Data.Entity.Database;
    using DomainModel;

    public class MoviesInitializer : 
        DropCreateDatabaseAlways<MovieDbContext>
        //DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {

            var movies = new InMemoryMoviesService().GetAllMovies().ToList();
            //var comments = (from m in movies
            //               from c in m.Comments
            //               select c).ToList();

            //comments.ForEach(c => context.Comments.Add(c));
            movies.ForEach(d => context.Movies.Add(d));
        }
    }
}