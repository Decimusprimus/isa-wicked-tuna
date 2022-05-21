using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;

namespace WickedTunaAPI.Auth.Service
{
    public interface IAuthService
    {
        Task<UserCredentials> LoginUser(LoginCredentials loginCredentials);

        UserCredentials RefreshToken(string token, string ipAddress);
    }
}
