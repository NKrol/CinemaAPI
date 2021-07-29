using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Entities.Users;

namespace CinemaAPI.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string NameCinema { get; set; }
        public virtual Adress Adress { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual List<Hall> Halls { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
