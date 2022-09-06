using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WickedTunaAPI.Cottages.Exceptions;
using WickedTunaAPI.Cottages.Service;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Controller
{
    [Route("api/cottages")]
    [ApiController]
    public class CottagesController : ControllerBase
    {
        private readonly ICottageService _cottageService;

        public CottagesController(ICottageService cottageService)
        {
            _cottageService = cottageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cottageService.GetAvailable());
        }

        [HttpGet("{id}")]
        public IActionResult GetCottageById(Guid id)
        {
            var cottage = _cottageService.GetCottageForId(id);
            return cottage != null ? Ok(cottage) : NotFound();
        }

        [HttpGet("{id}/images")]
        public IActionResult GetImagesForCottage(Guid id)
        {
            try
            {
                var images = _cottageService.GetImagesForCottage(id);
                return Ok(images);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{cottageId}/images/{name}")]
        public IActionResult GetCottageImageForName([FromRoute] Guid cottageId, [FromRoute]string name)
        {
            try
            {
                var image = _cottageService.GetCottageImageForId(cottageId, name);
                return image != null ? File(image, "image/jpeg") : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/image")]
        public IActionResult GetFirstImageForCottage(Guid id)
        {
            try
            {
                return File(_cottageService.GetFirstImageForCottage(id), "image/jpeg");
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("{id}/reservation")]
        public IActionResult CreateNewReservation([FromRoute]Guid id, [FromBody] CottageReservation cottageReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            if (cottageReservation.Start > cottageReservation.End || cottageReservation.End < cottageReservation.Start)
            {
                return BadRequest("Dates incorect!");
            }
            try
            {
                if(_cottageService.CreateNewReservation(id, cottageReservation, email) == null)
                {
                    return BadRequest("Already reserved!");
                }
                return Ok();
            }
            catch(CottageReservationException)
            {
                return BadRequest("ReservationException");
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("special-offers")]
        public IActionResult GetCottageSpecialOffers()
        {
            return Ok(_cottageService.GetCottageSpecialOffers());
        }

        [Authorize]
        [HttpPost("special-offers/{id}")]
        public IActionResult CreateSpecialOfferReservation([FromRoute] Guid id, [FromBody] CottageReservation cottageReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var res = _cottageService.ConfirmSpecialOffer(id, cottageReservation, email);
                return res != null ? Ok(res) : BadRequest('Already reseved!');
            } 
            catch(CottageReservationException)
            {
                return BadRequest("RegistrationException");
            }

        }

        [Authorize]
        [HttpGet("reservations/active")]
        public IActionResult GetActiveReservations()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var res = _cottageService.GetActiveReservations(email);
            return res != null ? Ok(res) : BadRequest();
        }

        [Authorize]
        [HttpGet("reservations/past")]
        public IActionResult GetPastReservations()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var res = _cottageService.GetPastReservations(email);
            return res != null ? Ok(res) : BadRequest();
        }

        [Authorize]
        [HttpPost("reservation/cancel/{id}")]
        public IActionResult CancelReservation([FromRoute] Guid id, [FromBody] CottageReservation cottageReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var res = _cottageService.CancelReservation(id, cottageReservation, email);
                return res ? Ok() : BadRequest();
            } 
            catch(CottageReservationException)
            {
                return BadRequest("ReservationException");
            }
        }

    }

    
}
