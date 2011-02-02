namespace MyMovies.WebApp.Models {
    using System.Collections.Generic;
    using System.Data.Entity.Database;
    using DomainModel;

    public class MoviesInitializer : DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {

            var movies = new List<Movie>
                             {

                                 new Movie
                                     {
                                         Title = "When Harry Met Sally1",
                                         Genre = "Romantic Comedy",
                                         Year = 2004
                                     },

                                 new Movie
                                     {
                                         Title = "Ghostbusters 2",
                                         Genre = "Comedy",
                                         Year = 2002
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

                               };


            comments.ForEach(c => context.Comments.Add(c));
            movies.ForEach(d => context.Movies.Add(d));
        }
    }
}