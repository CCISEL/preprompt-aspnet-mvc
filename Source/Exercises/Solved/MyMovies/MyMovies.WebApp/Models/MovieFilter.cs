using System;
using MyMovies.DomainModel;

namespace MyMovies.WebApp.Models
{
    public class MovieFilter
    {
        public string Title { get; set; }

        public int? Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public TimeSpan? Runtime { get; set; }
    }
}