using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WickedTunaCore.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
