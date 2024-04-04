using AutoMapper;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;

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

    public IEnumerable<VillaDTO> GetAllVillas()
    {
        var villas = _villaRepo.GetAllVillas();
        return _mapper.Map<IEnumerable<VillaDTO>>(villas);
    }

    public VillaDTO GetVillaById(int id)
    {
        var villa = _villaRepo.GetVillaById(id);
        return _mapper.Map<VillaDTO>(villa);
    }

    public int CreateVilla(CreateVillaDTO villa)
    {
        var existingVilla = _villaRepo.GetVillaByName(villa.Name);
        if(existingVilla != null)
        {
            throw new ArgumentException("Villa with this name already exists");
        }
        return _villaRepo.CreateVilla(_mapper.Map<Villa>(villa));
    }

    public void DeleteVilla(int id)
    {
        var villa = _villaRepo.GetVillaById(id);
        if(villa == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        _villaRepo.DeleteVilla(id);
    }

    public void UpdateVilla(int id, UpdateVillaDTO villa)
    {
        var existingVilla = _villaRepo.GetVillaById(id);
        if(existingVilla == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        _villaRepo.UpdateVilla(id, _mapper.Map<Villa>(villa));
    }

    public void UpdatePartialVilla(int id, JsonPatchDocument<UpdateVillaDTO> patch)
    {
        var villa = _villaRepo.GetVillaById(id);
        if(villa == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        
        var villaDTO = _mapper.Map<UpdateVillaDTO>(villa);
        patch.ApplyTo(villaDTO);
        var updatedVilla = _mapper.Map<Villa>(villaDTO);
        
        _villaRepo.UpdateVilla(id, updatedVilla);
    }
}