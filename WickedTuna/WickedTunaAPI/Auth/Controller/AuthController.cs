using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
using System.Web;
using WickedTunaAPI.Configuration;
using WickedTunaAPI.DTOs;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.Email;
using WickedTunaCore.Auth;
using WickedTunaInfrastructure;
using WickedTunaAPI.Auth.Service;
using WickedTunaAPI.Auth.Exceptions;
using WickedTunaAPI.Clients.Service;

namespace WickedTunaAPI.Auth.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly WickedTunaDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IClientService _clientService;
        public AuthController(IOptions<JwtBearerTokenSettings> jwtTokenOptions, UserManager<ApplicationUser> userManager, WickedTunaDbContext dbContext, IEmailService emailService, RoleManager<IdentityRole> roleManager, IAuthService authService, ITokenService tokenService, IClientService clientService)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _userManager = userManager;
            _dbContext = dbContext;
            _emailService = emailService;
            _roleManager = roleManager;
            _authService = authService;
            _tokenService = tokenService;
            _clientService = clientService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationForm registrationForm)
        {
            if (!ModelState.IsValid || registrationForm == null)
            {
                return BadRequest();
            }
            var indetityUser = new ApplicationUser() {UserName = registrationForm.Email, Email = registrationForm.Email };
            var result = await _userManager.CreateAsync(indetityUser, registrationForm.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }
            return Ok(new { Message = "User Reigstration Successful" });
        }

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody] ClientRegistrationForm registrationForm)
        {
            if (!ModelState.IsValid || registrationForm == null)
            {
                return BadRequest();
            }
            else if( !registrationForm.Password.Equals(registrationForm.PasswordRepeated))
            {
                return BadRequest();
            }
            var indetityUser = new ApplicationUser() { UserName = registrationForm.Email, Email = registrationForm.Email };
            var result = await _userManager.CreateAsync(indetityUser, registrationForm.Password);
            if(result.Succeeded)
            {
                if(!_roleManager.RoleExistsAsync("Client").Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Client";
                    IdentityResult roleRsult = _roleManager.CreateAsync(role).Result;
                    if (!roleRsult.Succeeded)
                    {
                        return BadRequest();
                    }
                }
                _userManager.AddToRoleAsync(indetityUser, "Client").Wait();
                _clientService.CreateNewUserAsClient(registrationForm, indetityUser.Id);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(indetityUser);
                var link = "http://localhost:4200/email/confirm?token=" + HttpUtility.UrlEncode(token) + "&email=" + indetityUser.Email;
                //var confirmationLink = Url.ActionLink("ConfirmEmail", "Email", new { token, email = indetityUser.Email }, null);
                await _emailService.SendEmailAsync(indetityUser.Email, "Confirm Email", link);
                return Ok(new { Message = "User Reigstration Successful" });
            }
            /*if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(indetityUser);
            var link = "http://localhost:4200/email/confirm?token=" + HttpUtility.UrlEncode(token) + "&email=" + indetityUser.Email;
            //var confirmationLink = Url.ActionLink("ConfirmEmail", "Email", new { token, email = indetityUser.Email }, null);
            await _emailService.SendEmailAsync(indetityUser.Email, "Confirm Email", link);
            return Ok(new { Message = "User Reigstration Successful" });*/
            return BadRequest();
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            credentials.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                UserCredentials userCredentials = await _authService.LoginUser(credentials);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("refreshToken", userCredentials.RefreshToken, cookieOptions);
                return Ok(userCredentials);
            }
            catch(UserNotFoundException)
            {
                return NotFound("User not found!");
            }
            catch(EmailNotConfirmedException)
            {
                return Unauthorized("Email not confirm!");
            }
            catch(PasswordIncorrectException)
            {
                return BadRequest("Password Incorrect!");
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
             
            /*
            ApplicationUser identityUser;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }
            if (!_userManager.IsEmailConfirmedAsync(identityUser).Result)
            {
                return BadRequest("Email not comfired!");
            }

            UserCredentials userCredentials = GetUserCredentials(identityUser);
            //var token = GenerateTokens(identityUser);
            //return Ok(new { Token = token, Message = "Success" });
            return Ok(userCredentials);*/


        }

       /* private UserCredentials GetUserCredentials(ApplicationUser identityUser)
        {
            UserCredentials userCredentials = new UserCredentials();
            userCredentials.Id = identityUser.Id;
            userCredentials.FirstName = identityUser.UserName;
            userCredentials.JwtToken = GenerateAccessToken(identityUser);
            userCredentials.RefreshToken = GenerateNewRefreshToken(identityUser);
            return userCredentials;
        }*/

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public IActionResult RefreshToken()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                var userCredentials = _authService.RefreshToken(token, ipAddress);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("refreshToken", userCredentials.RefreshToken, cookieOptions);
                return Ok(userCredentials);
            }
            catch(Exception)
            {
                return BadRequest();
            }

            /*
            var identityUser = _dbContext.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));

            // Get existing refresh token if it is valid and revoke it
            var existingRefreshToken = GetValidRefreshToken(token, identityUser);
            if (existingRefreshToken == null)
            {
                return new BadRequestObjectResult(new { Message = "Failed" });
            }

            existingRefreshToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingRefreshToken.RevokedOn = DateTime.UtcNow;

            // Generate new tokens
            var newToken = GenerateTokens(identityUser);
            return Ok(new { Token = newToken, Message = "Success" });
            */
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] StringToken token)
        {
            string refreshToken = token.Token ?? HttpContext.Request.Cookies["refreshToken"];
            //token = HttpContext.Request.Cookies["refreshToken"];
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                _authService.RevokeToken(refreshToken, ipAddress);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
            /*if(RevokeRefreshToken(token))
            {
                return Ok(new { Message = "Success" });
            }

            return new BadRequestObjectResult(new { Message = "Failed" });
            */
        }

        [Authorize]
        [HttpGet("user-profile")]
        public async Task<IActionResult> GetUserProfileInformation()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            try
            {
                var user = await _authService.GetUserInfomation(email);
                if(user != null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
    
        }

        [Authorize]
        [HttpPut("user-profile/{id}")]
        public async Task<IActionResult> UpdateUserInformation([FromBody] UserInfoDTO userInfo)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            if(!email.Equals(userInfo.Email))
            {
                return BadRequest();
            }
            try
            {
                var user = await _authService.UpdateUserInfo(userInfo);
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }

        }


            
        private RefreshToken GetValidRefreshToken(string token, ApplicationUser identityUser)
        {
            if (identityUser == null)
            {
                return null;
            }

            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            return IsRefreshTokenValid(existingToken) ? existingToken : null;
        }


        private bool RevokeRefreshToken(string token = null)
        {
            token = token == null ? HttpContext.Request.Cookies["refreshToken"] : token;
            var identityUser = _dbContext.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));
            if (identityUser == null)
            {
                return false;
            }

            // Revoke Refresh token
            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            existingToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress.ToString();
            existingToken.RevokedOn = DateTime.UtcNow;
            _dbContext.Update(identityUser);
            _dbContext.SaveChanges();
            return true;
        }


        private async Task<ApplicationUser> ValidateUser(LoginCredentials credentials)
        {
            var identityUser = await _userManager.FindByNameAsync(credentials.Username);
            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }

        private string GenerateTokens(ApplicationUser identityUser)
        {
            // Generate access token
            string accessToken = GenerateAccessToken(identityUser);

            // Generate refresh token and set it to cookie
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var refreshToken = GenerateRefreshToken(ipAddress, identityUser.Id);

            // Set Refresh Token Cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            // Save refresh token to database
            if (identityUser.RefreshTokens == null)
            {
                identityUser.RefreshTokens = new List<RefreshToken>();
            }

            identityUser.RefreshTokens.Add(refreshToken);
            _dbContext.Update(identityUser);
            _dbContext.SaveChanges();
            return accessToken;
        }

        private string GenerateAccessToken(ApplicationUser identityUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email)
                }),

                Expires = DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiryOn = DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.RefreshTokenExpiryInDays),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByIp = ipAddress,
                    UserId = userId
                };
            }
        }

        private string GenerateNewRefreshToken(ApplicationUser identityUser)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                var refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiryOn = DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.RefreshTokenExpiryInDays),
                    CreatedOn = DateTime.UtcNow,
                    CreatedByIp = ipAddress,
                    UserId = identityUser.Id,
                };
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

                // Save refresh token to database
                if (identityUser.RefreshTokens == null)
                {
                    identityUser.RefreshTokens = new List<RefreshToken>();
                }

                identityUser.RefreshTokens.Add(refreshToken);
                _dbContext.Update(identityUser);
                _dbContext.SaveChanges();
                return refreshToken.Token;
            }
        }

        private bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return false;
            }

            // Token already expired, then return false
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }
    }
}
