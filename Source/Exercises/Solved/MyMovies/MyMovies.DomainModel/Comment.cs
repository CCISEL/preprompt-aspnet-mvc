using System;

namespace MyMovies.DomainModel
{
    public class Comment
    {
        public String ID { get; set; }
        public String Description { get; set; }
        //public DateTime Date { get; set; }

        public int MovieID { get; set; }
    }
}