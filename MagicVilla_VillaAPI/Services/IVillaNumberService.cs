using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaNumberService
{
    Task<IEnumerable<VillaNumberDTO>> GetAllVillaNumbers();
    Task<VillaNumberDTO> GetVillaNumber(int villaNo);
    Task CreateVillaNumber(CreateVillaNumberDTO villaNumberCreate);
    Task DeleteVillaNumber(int villaNo);
    Task UpdateVillaNumber(UpdateVillaNumberDTO villaNumberUpdate);
}