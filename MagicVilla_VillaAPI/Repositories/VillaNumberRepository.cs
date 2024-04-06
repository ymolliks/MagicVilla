using System;
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

    public async Task<VillaNumber> GetVillaNumber(int id)
    {
        return await _db.GetInfoAsync<VillaNumber>(
            new
            {
                VillaNo = id
            }, 
            "GetVillaNumber"
        );
    }

    public async Task CreateVillaNumber(VillaNumber villaNumber)
    {
        await _db.ExecuteNonQueryAsync(
            new
            {
                villaNo = villaNumber.VillaNo,
                specialDetails = villaNumber.SpecialDetails,
                createdDate = DateTime.Now,
                updatedDate = (DateTime?)null
            },
            "CreateVillaNumber"
        );
    }
}