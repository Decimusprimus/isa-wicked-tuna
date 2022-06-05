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
    }
}
