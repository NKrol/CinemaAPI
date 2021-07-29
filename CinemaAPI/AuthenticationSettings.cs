using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public double JwtExpireDay { get; set; }
        public string JwtIssuer { get; set; }

    }
}
