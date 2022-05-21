using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.Auth.Exceptions;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.Auth.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> ValidateUserLoginCredentials(LoginCredentials loginCredentials)
        {
            var identetyUser = await _userManager.FindByNameAsync(loginCredentials.Username);
            if(identetyUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identetyUser, identetyUser.PasswordHash, loginCredentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identetyUser;
            }
            throw new UserNotFoundException();
        }
    }
}
