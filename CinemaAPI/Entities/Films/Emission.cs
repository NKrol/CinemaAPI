using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Emission
    {
        public int Id { get; set; }
        public string StateOfIssue { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}
