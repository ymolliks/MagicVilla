using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MagicVilla_VillaAPI.Repositories;

public interface IVillaNumberRepository
{
    Task<IEnumerable<VillaNumber>> GetAllVillaNumbers();
    Task<VillaNumber> GetVillaNumber(int villaNo);
    Task CreateVillaNumber(VillaNumber villaNumber);
    Task DeleteVillaNumber(int villaNo);
    Task UpdateVillaNumber(VillaNumber villaNumber);
}
