using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaCore.Users;

namespace WickedTunaAPI.Auth.Service
{
    public interface IAuthService
    {
        Task<UserCredentials> LoginUser(LoginCredentials loginCredentials);

        UserCredentials RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        Task<UserInfoDTO> GetUserInfomation(string email);
        Task<UserInfoDTO> UpdateUserInfo(UserInfoDTO userInf);
        Task<bool> UpdateUserPassword(UpdatePasswordDTO updatePassword, string email);
    }
}
