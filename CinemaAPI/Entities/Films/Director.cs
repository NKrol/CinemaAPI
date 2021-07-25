using System.Collections.Generic;

namespace CinemaAPI.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}