using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Repositories;

public interface IVillaRepository
{
    IEnumerable<VillaDTO> GetAllVillas();
    VillaDTO GetVillaById(int id);
    VillaDTO GetVillaByName(string name);
    int CreateVilla(VillaDTO villa);
    void DeleteVilla(int id);
    void UpdateVilla(int id, VillaDTO villa);
}