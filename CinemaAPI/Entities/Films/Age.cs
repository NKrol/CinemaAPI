using System.Collections.Generic;

namespace CinemaAPI.Entities
{
    public class Age
    {
        public int Id { get; set; }
        public string AgeRange { get; set; }

        public virtual List<Movie> Movies { get; set; }


    }
}