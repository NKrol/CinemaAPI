using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities
{
    public class Showing
    {
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Hall Hall { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfShow { get; set; }

    }
}
