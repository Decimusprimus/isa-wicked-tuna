using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Cottages.Service;

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
    }
}
