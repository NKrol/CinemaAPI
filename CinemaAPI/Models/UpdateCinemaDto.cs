using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class UpdateCinemaDto
    {
        public string NameCinema { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
