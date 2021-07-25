using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using Type = System.Type;

namespace CinemaAPI.Models
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public string ProjectionName { get; set; }
        public string Types1 { get; set; }
        public DateTime PremiereDate { get; set; }

    }
}
