using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class HallDto
    {
        public int Id { get; set; }
        public string NameHall { get; set; }
        public int Number { get; set; }
        public int NumberOfSeats { get; set; }
        public string Status { get; set; }

    }
}
