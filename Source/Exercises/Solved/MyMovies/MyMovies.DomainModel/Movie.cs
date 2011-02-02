using System.Collections.Generic;

namespace MyMovies.DomainModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "The Year must be between 1900 and 2100")]
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Image { get; set; }
        public TimeSpan Runtime { get; set; }
        public string Xpto1 { get; set; }
        
        //[StringLength(5)]


        public ICollection<Comment> Comments { get; set; }
    }
}