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

    public async Task<VillaNumberDTO> GetVillaNumber(int villaNo)
    {
        var villaNumber = await _villaNumberRepository.GetVillaNumber(villaNo);
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

    public async Task DeleteVillaNumber(int villaNo)
    {
        var villaNumber = await _villaNumberRepository.GetVillaNumber(villaNo);
        if(villaNumber == null)
        {
            throw new ArgumentException("VillaNumber does not exist");
        }
        await _villaNumberRepository.DeleteVillaNumber(villaNo);
    }

    public async Task UpdateVillaNumber(UpdateVillaNumberDTO villaNumberUpdate)
    {
        _villaNumberRepository.UpdateVillaNumber(_mapper.Map<VillaNumber>(villaNumberUpdate));
    }
}