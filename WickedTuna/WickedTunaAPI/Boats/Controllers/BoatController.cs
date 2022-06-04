using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Boats.Services;

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
    }
}
