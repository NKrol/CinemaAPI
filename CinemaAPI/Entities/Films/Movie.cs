using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Director Director { get; set; }
        public virtual List<Type> Types { get; set; }
        public virtual Age Age { get; set; }
        public virtual Emission Emission { get; set; }
        public virtual List<KindOfMovie> KindOfMovies { get; set; }
        public DateTime PremiereDate { get; set; }
    }
}
