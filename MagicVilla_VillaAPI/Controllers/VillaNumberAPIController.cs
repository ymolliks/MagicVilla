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

    public VillaNumberAPIController(IVillaNumberService villaNumberService)
    {
        _villaNumberService = villaNumberService;
        _response = new APIResponse();
    }
    
    [HttpGet]
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

    [HttpGet("{id:int}", Name = "GetVillaNumber")]
    public async Task<ActionResult<VillaNumberDTO>> GetVillaNumber(int id)
    {
        if(id == 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Invalid Villa Number" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        try
        {
            var villaNumber = await _villaNumberService.GetVillaNumber(id);
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
            await _villaNumberService.CreateVillaNumber(villaNumberCreate);
            _response.Result = villaNumberCreate;
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtRoute("GetVillaNumber", new { id = villaNumberCreate.VillaNo }, _response);
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