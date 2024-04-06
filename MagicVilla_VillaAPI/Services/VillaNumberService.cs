using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicVilla_VillaAPI.Repositories;
using MagicVilla_VillaAPI;

namespace MagicVilla_VillaAPI.Services;

public class VillaNumberService : IVillaNumberService
{
    private readonly IVillaNumberRepository _villaNumberRepository;
    public readonly IMapper _mapper;

    public VillaNumberService(IVillaNumberRepository villaNumberRepository,
                              IMapper mapper)
    {
        _villaNumberRepository = villaNumberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VillaNumberDTO>> GetAllVillaNumbers()
    {
        var villaNumbers = await _villaNumberRepository.GetAllVillaNumbers();
        return _mapper.Map<IEnumerable<VillaNumberDTO>>(villaNumbers);
    }

    public async Task<VillaNumberDTO> GetVillaNumber(int id)
    {
        var villaNumber = await _villaNumberRepository.GetVillaNumber(id);
        return _mapper.Map<VillaNumberDTO>(villaNumber);
    }

    public async Task CreateVillaNumber(CreateVillaNumberDTO villaNumberCreate)
    {
        var existingVillaNumber = await _villaNumberRepository.GetVillaNumber(villaNumberCreate.VillaNo);
        if(existingVillaNumber != null)
        {
            throw new ArgumentException("VillaNumber already exists");
        }
        var villaNumber = _mapper.Map<VillaNumber>(villaNumberCreate);
        await _villaNumberRepository.CreateVillaNumber(villaNumber);
    }
}