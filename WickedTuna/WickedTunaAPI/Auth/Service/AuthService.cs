﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.Auth.Exceptions;
using WickedTunaCore.Auth;
using WickedTunaCore.Users;
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

            UserCredentials userCredentials = await GetUserCredentials(applicationUser, loginCredentials.IpAddress);

            return userCredentials;
        }

        public UserCredentials RefreshToken(string token, string ipAddress)
        {
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

            return GetUserCredentials(applicationUser, ipAddress).Result;
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

        private async Task<UserCredentials> GetUserCredentials(ApplicationUser applicationUser, string ipAddress)
        {
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var role = roles.FirstOrDefault();
            return new UserCredentials()
            {
                Id = applicationUser.Id,
                Username = applicationUser.UserName,
                JwtToken = await _tokenService.GenerateAccesToken(applicationUser),
                RefreshToken = _tokenService.GenerateRefreshToken(applicationUser, ipAddress),
                UserRole = role,
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

        public async Task<UserInfoDTO> GetUserInfomation(string email)
        {
            var applicationUser = await _userManager.FindByNameAsync(email);
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var role = roles.FirstOrDefault();
            if(String.IsNullOrEmpty(role))
            {
                throw new Exception();
            }

            if(role.Equals("Client"))
            {
                var client = _dbContext.Clients.FirstOrDefault(c => c.UserId == applicationUser.Id);
                var user = new UserInfoDTO()
                {
                    Id = client.UserId,
                    Email = client.Email,
                    Name = client.Name,
                    Surname = client.Surname,
                    County = client.County,
                    City = client.City,
                    StreetName = client.StreetName,
                    PhoneNumber = client.PhoneNumber,
                };

                return user;
            } else if(role.Equals("SystemAdmin"))
            {
                var admin = _dbContext.SystemAdmins.FirstOrDefault(s => s.UserId == applicationUser.Id);
                var user = new UserInfoDTO()
                {
                    Id = admin.UserId,
                    Email = admin.Email,
                    Name = admin.Name,
                    Surname = admin.Surname,
                    County = admin.County,
                    City = admin.City,
                    StreetName = admin.StreetName,
                    PhoneNumber = admin.PhoneNumber,
                    PasswordChanged = admin.PasswordChanged,
                };
                return user;
            }
            return null;

        }

        public async Task<UserInfoDTO> UpdateUserInfo(UserInfoDTO userInf)
        {
            var applicationUser = await _userManager.FindByIdAsync(userInf.Id);
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var role = roles.FirstOrDefault();
            if (String.IsNullOrEmpty(role))
            {
                throw new Exception();
            }

            if (role.Equals("Client"))
            {
                var client = _dbContext.Clients.FirstOrDefault(c => c.UserId == applicationUser.Id);
                client.Name = userInf.Name;
                client.Surname = userInf.Surname;
                client.County = userInf.County;
                client.City = userInf.City;
                client.StreetName = userInf.StreetName;
                client.PhoneNumber = userInf.PhoneNumber;
                _dbContext.Clients.Update(client);
                _dbContext.SaveChanges();
                return userInf;
            }
            return null;

        }

        public async Task<bool> UpdateUserPassword(UpdatePasswordDTO updatePassword, string email)
        {
            var applicationUser = await _userManager.FindByNameAsync(email);
            var isPassowrdChanged = await _userManager.ChangePasswordAsync(applicationUser, updatePassword.oldPassword, updatePassword.newPassword);
            if (!isPassowrdChanged.Succeeded)
            {
                throw new PasswordIncorrectException();
            }
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var role = roles.FirstOrDefault();
            if (role.Equals("SystemAdmin"))
            {
                var admin = _dbContext.SystemAdmins.FirstOrDefault(a => a.UserId == applicationUser.Id);
                admin.PasswordChanged = true;
                _dbContext.SaveChanges();
            }
            return true;
            
        }
    }
}
