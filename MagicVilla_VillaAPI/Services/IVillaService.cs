using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaService
{
    IEnumerable<VillaDTO> GetAllVillas();
    VillaDTO GetVillaById(int id);
    int CreateVilla(VillaDTO villa);
}