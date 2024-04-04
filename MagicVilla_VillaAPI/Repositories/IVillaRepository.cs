using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repositories;

public interface IVillaRepository
{
    IEnumerable<Villa> GetAllVillas();
    Villa GetVillaById(int id);
    Villa GetVillaByName(string name);
    int CreateVilla(Villa villa);
    void DeleteVilla(int id);
    void UpdateVilla(int id, Villa villa);
}