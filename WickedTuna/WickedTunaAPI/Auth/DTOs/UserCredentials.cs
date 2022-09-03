using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WickedTunaAPI.Auth.DTOs
{
    public class UserCredentials
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string password { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserRole { get; set; }

    }
}
