using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string NameCinema { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual List<Hall> Halls { get; set; }
    }
}
