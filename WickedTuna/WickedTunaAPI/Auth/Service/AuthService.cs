using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.Auth.Exceptions;
using WickedTunaCore.Auth;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WickedTunaDbContext _dbContext;

        public AuthService(ITokenService tokenService, UserManager<ApplicationUser> userManager, WickedTunaDbContext dbContext)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<UserCredentials> LoginUser(LoginCredentials loginCredentials)
        {
            ApplicationUser applicationUser = await ValidateUserLoginCredentials(loginCredentials);

            UserCredentials userCredentials = GetUserCredentials(applicationUser, loginCredentials.IpAddress);

            return userCredentials;
        }

        public UserCredentials RefreshToken(string token, string ipAddress)
        {
            /* var applicationUser = _dbContext.Users
                 .Include(u => u.RefreshTokens)
                 .FirstOrDefault(u => u.RefreshTokens
                     .Any(r => r.Token == token && r.UserId == u.Id));*/

            // var existingToken = _tokenService.GetValidRefreshToken(token, applicationUser);

            var existingToken = _tokenService.GetValidRefreshToken(token);
            
            if(existingToken == null)
            {
                throw new InvalidTokenException();
            }

            var applicationUser = _dbContext.Users
                .FirstOrDefault(u => u.Id == existingToken.UserId);
            if(applicationUser == null )
            {
                throw new UserNotFoundException();
            }

            _tokenService.RevokeRefreshToken(existingToken, ipAddress);

            return GetUserCredentials(applicationUser, ipAddress);
        }

        private async Task<ApplicationUser> ValidateUserLoginCredentials(LoginCredentials loginCredentials)
        {
            var applicationUser = await _userManager.FindByNameAsync(loginCredentials.Username);
            if (applicationUser == null)
            {
                throw new UserNotFoundException();
            }
            if(_userManager.PasswordHasher.VerifyHashedPassword(applicationUser, applicationUser.PasswordHash, loginCredentials.Password) == PasswordVerificationResult.Failed)
            {
                throw new PasswordIncorrectException();
            }
            if(!_userManager.IsEmailConfirmedAsync(applicationUser).Result)
            {
                throw new EmailNotConfirmedException();
            }
            return applicationUser;
        }

        private UserCredentials GetUserCredentials(ApplicationUser applicationUser, string ipAddress)
        {
            return new UserCredentials()
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.UserName,
                JwtToken = _tokenService.GenerateAccesToken(applicationUser),
                RefreshToken = _tokenService.GenerateRefreshToken(applicationUser, ipAddress),
            };
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var existingToken = _tokenService.GetValidRefreshToken(token);

            if (existingToken == null)
            {
                throw new InvalidTokenException();
            }
            _tokenService.RevokeRefreshToken(existingToken, ipAddress);

        }
    }
}
