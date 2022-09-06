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
using WickedTunaAPI.Email.util;
using WickedTunaAPI.Email.Service;

namespace WickedTunaAPI.Auth.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;
        private readonly IClientService _clientService;
        private readonly IEmailSender _emailSender;
        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IAuthService authService, ITokenService tokenService, IClientService clientService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
            _clientService = clientService;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationForm registrationForm)
        {
            if (!ModelState.IsValid || registrationForm == null)
            {
                return BadRequest();
            }
            var indetityUser = new ApplicationUser() { UserName = registrationForm.Email, Email = registrationForm.Email };
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
            else if (!registrationForm.Password.Equals(registrationForm.PasswordRepeated))
            {
                return BadRequest();
            }
            var indetityUser = new ApplicationUser() { UserName = registrationForm.Email, Email = registrationForm.Email };
            var result = await _userManager.CreateAsync(indetityUser, registrationForm.Password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("Client").Result)
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
                var emailMessage = new Message(new string[] { indetityUser.Email }, "Conformation Link", "Wellcome to WickedTuna! Plese confirm your email on link: " + link);
                _emailSender.SendEmail(emailMessage);

                return Ok(new { Message = "User Reigstration Successful" });
            }
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
            catch (UserNotFoundException)
            {
                return NotFound("User not found!");
            }
            catch (EmailNotConfirmedException)
            {
                return Unauthorized("Email not confirm!");
            }
            catch (PasswordIncorrectException)
            {
                return BadRequest("Password Incorrect!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh-token")]
        public IActionResult RefreshToken([FromBody] StringToken token)
        {
            string refreshToken = token.Token ?? HttpContext.Request.Cookies["refreshToken"];
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                var userCredentials = _authService.RefreshToken(refreshToken, ipAddress);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("refreshToken", userCredentials.RefreshToken, cookieOptions);
                return Ok(userCredentials);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
            catch (SecurityTokenExpiredException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
                if (user != null)
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
            if (!email.Equals(userInfo.Email))
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

        [Authorize]
        [HttpPost("password")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdatePasswordDTO updatePassword)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var succes = await _authService.UpdateUserPassword(updatePassword, email);
                return Ok("Password changed!");
            }
            catch (PasswordIncorrectException)
            {
                return BadRequest("Password is incorrect!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    
    }

}
