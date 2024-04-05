using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Data;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Repositories;

public class VillaRepository : IVillaRepository
{
    private readonly IDapperDbContext _db;

    public VillaRepository(IDapperDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Villa>> GetAllVillas()
    {
        var villas = await _db.GetInfoListAsync<Villa>(null, "GetVillas");
        return villas;
    }

    public async Task<Villa> GetVillaById(int id)
    {
        var villa = await _db.GetInfoAsync<Villa>(
            new 
            {
                id = id
            }, 
            "GetVillaById"
        );
        
        return villa;
    }

    public async Task<Villa> GetVillaByName(string name)
    {
        var villa = await _db.GetInfoAsync<Villa>(new {name = name}, "GetVillaByName");
        return villa;
    }

    public async Task<int> CreateVilla(Villa villa)
    {
        var Id = await _db.ExecuteScalarAsync<int>(
            new
            {
                Name = villa.Name,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Details = villa.Details,
                Rate = villa.Rate, 
                ImageURL = villa.ImageURL,
                Amenity = villa.Amenity,
                CreatedDate = DateTime.Now
            },
            "CreateVilla"
        );
        return Id;
    }

    public async Task DeleteVilla(int id)
    {
        await _db.ExecuteNonQueryAsync(
            new
            {
                id = id
            },
            "DeleteVilla"
        );
    }

    public async Task UpdateVilla(int id, Villa villa)
    {
        await _db.ExecuteNonQueryAsync(
            new
            {
                Id = id,
                Name = villa.Name,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Details = villa.Details,
                Rate = villa.Rate,
                ImageURL = villa.ImageURL,
                Amenity = villa.Amenity,
                UpdatedDate = DateTime.Now
            },
            "UpdateVilla"
        );
    }
}