using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Models
{
    public class CreateCinemaDto
    {
        [Required]
        [MaxLength(30)]
        public string NameCinema { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
