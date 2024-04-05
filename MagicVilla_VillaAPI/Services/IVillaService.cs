using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaService
{
    Task<IEnumerable<VillaDTO>> GetAllVillas();
    Task<VillaDTO> GetVillaById(int id);
    Task<int> CreateVilla(CreateVillaDTO villa);
    Task DeleteVilla(int id);
    Task UpdateVilla(int id, UpdateVillaDTO villa);
    Task UpdatePartialVilla(int id, JsonPatchDocument<UpdateVillaDTO> patch);
}