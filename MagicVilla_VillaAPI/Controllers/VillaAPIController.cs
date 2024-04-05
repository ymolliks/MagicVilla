using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;
        
        public VillaAPIController(IDapperDbContext db,
                                  IVillaService villaService,
                                  IMapper mapper)
        {
            _db = db;
            _villaService = villaService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            var villas = await _villaService.GetAllVillas();
            return Ok(villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = await _villaService.GetVillaById(id);
            
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
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] CreateVillaDTO createDTO)
        {
            if(createDTO == null)
            {
                return BadRequest(createDTO);
            }

            try
            {
                var villaDTO = _mapper.Map<VillaDTO>(createDTO);
                villaDTO.Id = await _villaService.CreateVilla(createDTO);
                return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
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
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            
            try
            {
                await _villaService.DeleteVilla(id);
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
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] UpdateVillaDTO updateDTO)
        {
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _villaService.UpdateVilla(id, updateDTO);
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
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<UpdateVillaDTO> patch)
        {
            if(id == 0 || patch == null)
            {
                return BadRequest();
            }

            try
            {
                await _villaService.UpdatePartialVilla(id, patch);
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