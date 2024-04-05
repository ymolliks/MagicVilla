using AutoMapper;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Services;

public class VillaService : IVillaService
{
    private readonly IVillaRepository _villaRepo;
    private readonly IMapper _mapper;

    public VillaService(IVillaRepository villaRepo,
                        IMapper mapper)
    {
        _villaRepo = villaRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VillaDTO>> GetAllVillas()
    {
        var villas = await _villaRepo.GetAllVillas();
        return _mapper.Map<IEnumerable<VillaDTO>>(villas);
    }

    public async Task<VillaDTO> GetVillaById(int id)
    {
        var villa = await _villaRepo.GetVillaById(id);
        return _mapper.Map<VillaDTO>(villa);
    }

    public async Task<int> CreateVilla(CreateVillaDTO villa)
    {
        var existingVilla = await _villaRepo.GetVillaByName(villa.Name);
        if(existingVilla != null)
        {
            throw new ArgumentException("Villa with this name already exists");
        }
        return await _villaRepo.CreateVilla(_mapper.Map<Villa>(villa));
    }

    public async Task DeleteVilla(int id)
    {
        var villa = await _villaRepo.GetVillaById(id);
        if(villa == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        await _villaRepo.DeleteVilla(id);
    }

    public async Task UpdateVilla(int id, UpdateVillaDTO villa)
    {
        var existingVilla = await _villaRepo.GetVillaById(id);
        if(existingVilla == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        await _villaRepo.UpdateVilla(id, _mapper.Map<Villa>(villa));
    }

    public async Task UpdatePartialVilla(int id, JsonPatchDocument<UpdateVillaDTO> patch)
    {
        var villa = await _villaRepo.GetVillaById(id);
        if(villa == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        
        var villaDTO = _mapper.Map<UpdateVillaDTO>(villa);
        patch.ApplyTo(villaDTO);
        var updatedVilla = _mapper.Map<Villa>(villaDTO);
        
        await _villaRepo.UpdateVilla(id, updatedVilla);
    }
}