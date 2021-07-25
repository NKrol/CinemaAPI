using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class KindOfMovie
    {
        public int Id { get; set; }
        public string Projections { get; set; }
        public bool AddFee { get; set; }
        public double FeeAmount { get; set; }

        public virtual List<Movie> Movies { get; set; }

    }
}
