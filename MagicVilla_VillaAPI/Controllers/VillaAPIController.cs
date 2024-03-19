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

        [HttpGet("{id:int}")]
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
    }
}