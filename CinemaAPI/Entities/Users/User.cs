using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role{ get; set; }
        public int? DetailsAccountId { get; set; }

        public virtual DetailsAccount DetailsAccount { get; set; }

    }
}
