using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Entities;
using Type = System.Type;

namespace CinemaAPI.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Types { get; set; }
        public string Age { get; set; }
        public string Emission { get; set; }
        public  List<string> KindOfMovies { get; set; }
        public DateTime PremiereDate { get; set; }
    }
}
