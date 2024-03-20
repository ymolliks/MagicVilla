using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Newtonsoft.Json;
using MagicVilla_VillaAPI.Data;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("villa")]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.VillaList);
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
            
            var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            
            return Ok(VillaStore.VillaList.FirstOrDefault(v => v.Id == id));    
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

            if(VillaStore.VillaList.Any(v => v.Name == villa.Name))
            {
                ModelState.AddModelError("AlreadyExistsError", "Villa with this name already exists");
                return BadRequest(ModelState);
            }
            
            if(villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villa.Id = VillaStore.VillaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.VillaList.Add(villa);
            
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
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

            var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            if(villa == null)
            {
                return NotFound();
            }

            VillaStore.VillaList.Remove(villa);            
            return NoContent();
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

            var v = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            if(v == null)
            {
                return NotFound();
            }

            v.Name = villa.Name;
            v.Occupancy = villa.Occupancy;
            v.Sqft = villa.Sqft;
            return NoContent();
        }
    }
}