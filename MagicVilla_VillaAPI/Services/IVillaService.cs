using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaService
{
    IEnumerable<VillaDTO> GetAllVillas();
    VillaDTO GetVillaById(int id);
    int CreateVilla(CreateVillaDTO villa);
    void DeleteVilla(int id);
    void UpdateVilla(int id, UpdateVillaDTO villa);
    void UpdatePartialVilla(int id, JsonPatchDocument<UpdateVillaDTO> patch);
}