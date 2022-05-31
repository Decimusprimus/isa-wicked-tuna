using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WickedTunaCore.Users;

namespace WickedTunaCore.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public Client Client { get; set; }
        public SystemAdmin SystemAdmin { get; set; }
        public BoatOwner BoatOwner { get; set; }
        public CottageOwner CottageOwner { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
