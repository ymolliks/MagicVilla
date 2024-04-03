using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Newtonsoft.Json;
using MagicVilla_VillaAPI.Data;
using Microsoft.AspNetCore.JsonPatch;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Services;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("villa")]
    public class VillaAPIController : ControllerBase
    {
        private readonly IDapperDbContext _db;
        private readonly IVillaService _villaService;
        
        public VillaAPIController(IDapperDbContext db,
                                  IVillaService villaService)
        {
            _db = db;
            _villaService = villaService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            var villas = _villaService.GetAllVillas();
            return Ok(villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = _villaService.GetVillaById(id);
            
            if(villa == null)
            {
                return NotFound();
            }
            
            return Ok(villa);    
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
        {
            if(villa == null)
            {
                return BadRequest(villa);
            }

            if(villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            try
            {
                villa.Id = _villaService.CreateVilla(villa);
                return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("AlreadyExistsError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            
            try
            {
                _villaService.DeleteVilla(id);
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("NotFoundError", ex.Message);
                return NotFound(ModelState);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villa)
        {
            if(villa == null || id != villa.Id)
            {
                return BadRequest();
            }

            try
            {
                _villaService.UpdateVilla(id, villa);
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("NotFoundError", ex.Message);
                return NotFound(ModelState);
            }
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patch)
        {
            if(id == 0 || patch == null)
            {
                return BadRequest();
            }

            try
            {
                _villaService.UpdatePartialVilla(id, patch);
                return NoContent();
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError("NotFoundError", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}