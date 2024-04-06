using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MagicVilla_VillaAPI.Repositories;

public class VillaNumberRepository : IVillaNumberRepository
{
    private readonly IDapperDbContext _db;

    public VillaNumberRepository(IDapperDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<VillaNumber>> GetAllVillaNumbers()
    {
        return await _db.GetInfoListAsync<VillaNumber>(null, "GetAllVillaNumbers");
    }
}