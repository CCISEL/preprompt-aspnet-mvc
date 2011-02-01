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
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        //public string Director { get; set; }

        [Required]
        [Range(5, 100, ErrorMessage = "The price must be between $5 and $100")]
        public decimal Price { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}