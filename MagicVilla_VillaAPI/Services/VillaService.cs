using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;

namespace MagicVilla_VillaAPI.Services;

public class VillaService : IVillaService
{
    private readonly IVillaRepository _villaRepo;

    public VillaService(IVillaRepository villaRepo)
    {
        _villaRepo = villaRepo;
    }

    public IEnumerable<VillaDTO> GetAllVillas()
    {
        return _villaRepo.GetAllVillas();
    }

    public VillaDTO GetVillaById(int id)
    {
        return _villaRepo.GetVillaById(id);
    }

    public int CreateVilla(VillaDTO villa)
    {
        var villaExists = _villaRepo.GetVillaByName(villa.Name);
        if(villaExists != null)
        {
            throw new ArgumentException("Villa with this name already exists");
        }
        return _villaRepo.CreateVilla(villa);
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

    public void UpdateVilla(int id, VillaDTO villa)
    {
        var v = _villaRepo.GetVillaById(id);
        if(v == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        _villaRepo.UpdateVilla(id, villa);
    }

    public void UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patch)
    {
        var villa = _villaRepo.GetVillaById(id);
        if(villa == null)
        {
            throw new ArgumentException("Villa with this id does not exist");
        }
        patch.ApplyTo(villa);
        _villaRepo.UpdateVilla(id, villa);
    }
}