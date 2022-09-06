using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.Configuration;
using WickedTunaCore.Auth;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Auth.Service
{
    public class TokenService : ITokenService
    {

        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WickedTunaDbContext _dbContext;

        public TokenService(IOptions<JwtBearerTokenSettings> jwtTokenOptions, WickedTunaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public async Task<string> GenerateAccesToken(ApplicationUser applicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);
            var roles = await _userManager.GetRolesAsync(applicationUser);
            var role = roles.FirstOrDefault();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, applicationUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, applicationUser.Email),
                    new Claim(ClaimTypes.Role, role)
                }),

                Expires = DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(ApplicationUser applicationUser, string ipAddress)
        {
            /*var refreshToken = _dbContext.Entry(applicationUser)
                    .Collection(u => u.RefreshTokens)
                    .Query()
                        .Where(r => r.ExpiryOn > DateTime.Now)
                        .FirstOrDefault();
            */
            var refreshToken = _dbContext.RefreshTokens
                .Where(r => r.UserId == applicationUser.Id && r.ExpiryOn > DateTime.UtcNow && r.RevokedByIp == null)
                .FirstOrDefault();
            if( refreshToken != null)
            {
                return refreshToken.Token;
            }

            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiryOn = DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.RefreshTokenExpiryInDays),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByIp = ipAddress,
                    UserId = applicationUser.Id,
                };
                
                //applicationUser.RefreshTokens.Add(refreshToken);
                _dbContext.RefreshTokens.Add(refreshToken);
                //_dbContext.Update(applicationUser);
                _dbContext.SaveChanges();
                return refreshToken.Token;
            }
        }

        /* public string DoRefreshToken(string token, ApplicationUser applicationUser, string ipAddress)
         {
             var validRefreshToken = GetValidRefreshToken(token, applicationUser);
             if(validRefreshToken == null)
             {
                 return null;
             }

         }*/
        /* private RefreshToken GetValidRefreshToken(string token, ApplicationUser applicationUser)
        {
            var existingToken = _dbContext.Entry(applicationUser)
                .Collection(u => u.RefreshTokens)
                .Query()
                    .Where(r => r.Token == token)
                    .FirstOrDefault();

            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return null;
            }
            
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return null;
            }

            return existingToken;
        }*/

        public RefreshToken GetValidRefreshToken(string token)
        {
            var existingToken = _dbContext.RefreshTokens
                .Where(r => r.Token == token)
                .FirstOrDefault();

            if (existingToken == null)
            {
                return null;
            }

            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return null;
            }

            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                throw new SecurityTokenExpiredException();
            }

            return existingToken;
        }

        public void RevokeRefreshToken(RefreshToken token, string ipAddress)
        {
            token.RevokedByIp = ipAddress;
            token.RevokedOn = DateTime.UtcNow;
            _dbContext.Update(token);
            _dbContext.SaveChanges();
        }
    }
}
