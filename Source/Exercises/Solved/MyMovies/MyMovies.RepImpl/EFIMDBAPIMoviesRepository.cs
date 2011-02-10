using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MyMovies.Rep;

namespace MyMovies.RepImpl {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Rep.Helpers.Collections;

    public class EFIMDBAPIMoviesRepository : EFDbContextRepository<Movie, int>, IMoviesRepository
    {
        private readonly MovieDbContext _moviesContext;

        public EFIMDBAPIMoviesRepository(MovieDbContext moviesContext) : base(moviesContext)
        {
            _moviesContext = moviesContext;
        }

        #region Implementation of IMoviesRepository

        public Movie SearchByTitle(string title)
        {
            return TheIMDbAPI.SearchByTitle(title);
        }

        public IQueryable<string> GetGenres()
        {
            return _moviesContext.Movies.Select(m => m.Genre).Distinct();
        }

        #endregion
    }
}