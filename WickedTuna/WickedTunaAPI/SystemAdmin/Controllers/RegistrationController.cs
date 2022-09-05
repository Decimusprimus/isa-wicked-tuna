using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.SystemAdmin.Services;

namespace WickedTunaAPI.SystemAdmin.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRequestService _registrationRequestService;

        public RegistrationController(IRegistrationRequestService registrationRequestService)
        {
            _registrationRequestService = registrationRequestService;
        }

        [HttpPost("user")]
        public IActionResult RegisterUser([FromBody] UserRegistrationForm registrationForm)
        {
            if (!ModelState.IsValid || registrationForm == null)
            {
                return BadRequest();
            }
            else if (!registrationForm.Password.Equals(registrationForm.PasswordRepeated))
            {
                return BadRequest();
            }

            _registrationRequestService.CreateRegistrationRequest(registrationForm);
            return Ok();
        }

        [HttpGet("toreview")]
        public IActionResult GetRequestToReview()
        {
            return Ok(_registrationRequestService.GetRequestToReview());
        }
    }
}
