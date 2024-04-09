using System;
using System.Net;
using AutoMapper;
using System.Collections.Generic;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace MagicVilla_VillaAPI.Controllers;

[ApiController]
[Route("villanumber")]
public class VillaNumberAPIController : ControllerBase
{
    protected APIResponse _response;
    private readonly IVillaNumberService _villaNumberService;
    private readonly IVillaService _villaService;

    public VillaNumberAPIController(IVillaNumberService villaNumberService,
                                    IVillaService villaService)
    {
        _villaNumberService = villaNumberService;
        _response = new APIResponse();
        _villaService = villaService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> GetAllVillaNumbers()
    {
        try
        {
            var villaNumbers = await _villaNumberService.GetAllVillaNumbers();
            _response.Result = villaNumbers;
            _response.StatusCode = HttpStatusCode.OK;;
            return Ok(_response);
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpGet("{villaNo:int}", Name = "GetVillaNumber")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VillaNumberDTO>> GetVillaNumber(int villaNo)
    {
        if(villaNo == 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Invalid Villa Number" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        try
        {
            var villaNumber = await _villaNumberService.GetVillaNumber(villaNo);
            if(villaNumber == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Villa Number not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            _response.Result = villaNumber;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpPost(Name = "CreateVillaNumber")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> CreateVillaNumber(CreateVillaNumberDTO villaNumberCreate)
    {
        if(villaNumberCreate == null || villaNumberCreate.VillaNo == 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "VillaNumber is null or VillaNo is 0" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        try
        {
            var villa = await _villaService.GetVillaById(villaNumberCreate.VillaId);
            if(villa == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { $"Villa with Id {villaNumberCreate.VillaId} not found" };
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            
            await _villaNumberService.CreateVillaNumber(villaNumberCreate);
            _response.Result = villaNumberCreate;
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtRoute("GetVillaNumber", new { villaNo = villaNumberCreate.VillaNo }, _response);
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);            
        }
    }

    [HttpDelete("{villaNo:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int villaNo)
    {
        if(villaNo == 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Invalid Villa Number" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        try
        {
            await _villaNumberService.DeleteVillaNumber(villaNo);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch(ArgumentException ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpPut("{villaNo:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villaNo, UpdateVillaNumberDTO villaNumberUpdate)
    {
        if(villaNo == 0 || villaNumberUpdate == null || villaNo != villaNumberUpdate.VillaNo)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Invalid Villa Number" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        try
        {
            var villaNumber = await _villaNumberService.GetVillaNumber(villaNo);
            if(villaNumber == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Villa Number not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            await _villaNumberService.UpdateVillaNumber(villaNumberUpdate);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch(Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }
}