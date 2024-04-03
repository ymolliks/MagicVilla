using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repositories;

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
}