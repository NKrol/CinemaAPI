using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string NameCinema { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Movies { get; set; }
        public int Halls { get; set; }

    }
}
