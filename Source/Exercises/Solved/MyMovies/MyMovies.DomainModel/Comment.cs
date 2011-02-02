using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.DomainModel
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public String Description { get; set; }

        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5")]
        public int Rating { get; set; }

        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }


    }
}