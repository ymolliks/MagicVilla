using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Data;

namespace MagicVilla_VillaAPI.Repositories;

public class VillaRepository : IVillaRepository
{
    private readonly IDapperDbContext _db;

    public VillaRepository(IDapperDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Villa> GetAllVillas()
    {
        var villas = _db.GetInfoList<Villa>(null, "GetVillas");
        return villas;
    }

    public Villa GetVillaById(int id)
    {
        var villa = _db.GetInfo<Villa>(
            new 
            {
                id = id
            }, 
            "GetVillaById"
        );
        
        return villa;
    }

    public Villa GetVillaByName(string name)
    {
        var villa = _db.GetInfo<Villa>(new {name = name}, "GetVillaByName");
        return villa;
    }

    public int CreateVilla(Villa villa)
    {
        var Id = _db.ExecuteScalar<int>(
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

    public void DeleteVilla(int id)
    {
        _db.ExecuteNonQuery(
            new
            {
                id = id
            },
            "DeleteVilla"
        );
    }

    public void UpdateVilla(int id, Villa villa)
    {
        _db.ExecuteNonQuery(
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