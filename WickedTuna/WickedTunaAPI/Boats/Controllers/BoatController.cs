using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WickedTunaAPI.Boats.Exceptions;
using WickedTunaAPI.Boats.Services;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Controllers
{
    [Route("api/boats")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;

        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpGet]
        public IActionResult GetAllBoats()
        {
            return Ok(_boatService.GetAllBoats());
        }

        [HttpGet("{id}")]
        public IActionResult GetBoatById(Guid id)
        {
            var boat = _boatService.GetBoatForId(id);
            return boat != null ? Ok(boat) : NotFound();
        }

        [HttpGet("{id}/images")]
        public IActionResult GetImagesForBoat(Guid id)
        {
            try
            {
                var images = _boatService.GetImagesForBoat(id);
                return Ok(images);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{boatId}/images/{name}")]
        public IActionResult GetBoatImageForName([FromRoute] Guid boatId, [FromRoute] string name)
        {
            try
            {
                var image = _boatService.GetBoatImageForId(boatId, name);
                return image != null ? File(image, "image/jpeg") : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/image")]
        public IActionResult GetFirstImageForBoat(Guid id)
        {
            try
            {
                return File(_boatService.GetFirstImageForBoat(id), "image/jpeg");
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost("{id}/reservation")]
        public IActionResult CreateNewReservation([FromRoute] Guid id, [FromBody] BoatReservation boatReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            if (boatReservation.Start > boatReservation.End || boatReservation.End < boatReservation.Start)
            {
                return BadRequest("Dates incorect!");
            }
            try
            {
                if(_boatService.CreateNewReservation(id, boatReservation, email) == null)
                {
                    return BadRequest("Already reserved!");
                }
                return Ok();
            }
            catch (BoatReservationException)
            {
                return BadRequest("ReservationException");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("special-offers")]
        public IActionResult GetBoatSpecialOffers()
        {
            return Ok(_boatService.GetBoatSpecialOffers());
        }

        [Authorize]
        [HttpPost("special-offers/{id}")]
        public IActionResult CreateSpecialOfferReservation([FromRoute] Guid id, [FromBody] BoatReservation boatReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var res = _boatService.ConfirmSpecialOffer(id, boatReservation, email);
                return res != null ? Ok(res) : BadRequest("Already reserved!");
            } catch(BoatReservationException)
            {
                return BadRequest("RegistrationException");
            }

        }

        [Authorize]
        [HttpGet("reservations/active")]
        public IActionResult GetActiveReservations()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var res = _boatService.GetActiveReservations(email);
            return res != null ? Ok(res) : BadRequest();
        }

        [Authorize]
        [HttpGet("reservations/past")]
        public IActionResult GetPastReservations()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var res = _boatService.GetPastReservations(email);
            return res != null ? Ok(res) : BadRequest();
        }

        [Authorize]
        [HttpPost("reservation/cancel/{id}")]
        public IActionResult CancelReservation([FromRoute] Guid id, [FromBody] BoatReservation boatReservation)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var res = _boatService.CancelReservation(id, boatReservation, email);
                return res ? Ok() : BadRequest();
            }
            catch (BoatReservationException)
            {
                return BadRequest("ReservationException");
            }
        }
    }
}
