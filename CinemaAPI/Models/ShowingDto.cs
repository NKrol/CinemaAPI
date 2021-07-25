using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class ShowingDto
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
        public string FirstNameDirector { get; set; }
        public string LastNameDirector { get; set; }
        public List<string> Types { get; set; }
        public string Ages { get; set; }
        public string Emisson { get; set; }
        public string Projections { get; set; }
        public DateTime PremiereDate { get; set; }
        public string NameCinema { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NameHall { get; set; }
        public int NumberOfSeats { get; set; }

    }
}
