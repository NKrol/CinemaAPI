using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public virtual List<Movie> Movies { get; set; }

    }
}
