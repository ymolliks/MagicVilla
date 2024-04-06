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
            _response.StatusCode = HttpStatusCode.InternalServerError;;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }
}