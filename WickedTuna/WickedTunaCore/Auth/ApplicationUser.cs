using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WickedTunaCore.Users;

namespace WickedTunaCore.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }
        public Client Client { get; set; }
        public SystemAdmin SystemAdmin { get; set; }
        public BoatOwner BoatOwner { get; set; }

        //public TUser User { get; set; }

    }
}
