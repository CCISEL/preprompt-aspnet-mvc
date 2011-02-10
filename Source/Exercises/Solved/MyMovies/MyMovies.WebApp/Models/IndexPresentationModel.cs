using System.Collections.Generic;
using MyMovies.DomainModel;

namespace MyMovies.WebApp.Models
{
    public class IndexPresentationModel
    {
        public ICollection<Movie> Movies { get;set; }

        public MovieFilter Filter { get;set; }
    }
}