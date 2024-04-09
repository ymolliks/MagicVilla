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

    public async Task<VillaNumber> GetVillaNumber(int villaNo)
    {
        return await _db.GetInfoAsync<VillaNumber>(
            new
            {
                villaNo
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
                villaId = villaNumber.VillaId,
                specialDetails = villaNumber.SpecialDetails,
                createdDate = DateTime.Now,
                updatedDate = (DateTime?)null
            },
            "CreateVillaNumber"
        );
    }

    public async Task DeleteVillaNumber(int villaNo)
    {
        await _db.ExecuteNonQueryAsync(
            new
            {
                villaNo
            },
            "DeleteVillaNumber"
        );
    }

    public async Task UpdateVillaNumber(VillaNumber villaNumber)
    {
        await _db.ExecuteNonQueryAsync(
            new
            {
                villaNo = villaNumber.VillaNo,
                villaId = villaNumber.VillaId,
                specialDetails = villaNumber.SpecialDetails,
                updatedDate = DateTime.Now
            },
            "UpdateVillaNumber"
        );
    }
}