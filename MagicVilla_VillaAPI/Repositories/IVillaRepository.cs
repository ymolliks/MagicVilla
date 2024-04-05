using MagicVilla_VillaAPI.Models;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Repositories;

public interface IVillaRepository
{
    Task<IEnumerable<Villa>> GetAllVillas();
    Task<Villa> GetVillaById(int id);
    Task<Villa> GetVillaByName(string name);
    Task<int> CreateVilla(Villa villa);
    Task DeleteVilla(int id);
    Task UpdateVilla(int id, Villa villa);
}
