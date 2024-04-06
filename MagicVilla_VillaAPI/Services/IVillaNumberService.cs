using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Services;

public interface IVillaNumberService
{
    Task<IEnumerable<VillaNumberDTO>> GetAllVillaNumbers();
    Task<VillaNumberDTO> GetVillaNumber(int id);
    Task CreateVillaNumber(CreateVillaNumberDTO villaNumberCreate);
}