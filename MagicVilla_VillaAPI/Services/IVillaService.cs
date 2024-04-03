using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaService
{
    IEnumerable<VillaDTO> GetAllVillas();
    VillaDTO GetVillaById(int id);
    int CreateVilla(VillaDTO villa);
    void DeleteVilla(int id);
    void UpdateVilla(int id, VillaDTO villa);
    void UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patch);
}