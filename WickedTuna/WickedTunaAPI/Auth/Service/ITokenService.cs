using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.Auth.Service
{
    public interface ITokenService
    {
        string GenerateAccesToken(ApplicationUser applicationUser);
        string GenerateRefreshToken(ApplicationUser applicationUser, string ipAddress);
       // string DoRefreshToken(string token, ApplicationUser applicationUser, string ipAddress);
        //RefreshToken GetValidRefreshToken(string token, ApplicationUser applicationUser);
        RefreshToken GetValidRefreshToken(string token);
        void RevokeRefreshToken(RefreshToken token, string ipAddress);
    }
}
