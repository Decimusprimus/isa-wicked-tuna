using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.Email.Controller
{
    [Route("api/mail")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private UserManager<ApplicationUser> _userMangager;

        public EmailController(UserManager<ApplicationUser> userMangager)
        {
            _userMangager = userMangager;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            if (token == null || email == null)
            {
                return BadRequest();
            }

            var user = await _userMangager.FindByEmailAsync(email);
            if(user == null)
            {
                return BadRequest();
            }

            var result = await _userMangager.ConfirmEmailAsync(user, token);

            if(result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
