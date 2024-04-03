using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Repositories;

public class VillaRepository : IVillaRepository
{
    private readonly IDapperDbContext _db;

    public VillaRepository(IDapperDbContext db)
    {
        _db = db;
    }

    public IEnumerable<VillaDTO> GetAllVillas()
    {
        var villas = _db.GetInfoList<VillaDTO>(null, "GetVillas");
        return villas;
    }

    public VillaDTO GetVillaById(int id)
    {
        var villa = _db.GetInfo<VillaDTO>(
            new 
            {
                id = id
            }, 
            "GetVillaById"
        );
        
        return villa;
    }

    public VillaDTO GetVillaByName(string name)
    {
        var villa = _db.GetInfo<VillaDTO>(new {name = name}, "GetVillaByName");
        return villa;
    }

    public int CreateVilla(VillaDTO villa)
    {
        var Id = _db.ExecuteScalar<int>(
            new
            {
                Name = villa.Name,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                Details = villa.Details,
                Rate = 0, 
                ImageURL = villa.ImageURL,
                Amenity = villa.Amenity,
                CreatedDate = DateTime.Now,
                UpdatedDate = (float?)null
            },
            "InsertVilla"
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

    public void UpdateVilla(int id, VillaDTO villa)
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