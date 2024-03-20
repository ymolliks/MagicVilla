using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList { get; set; } = new List<VillaDTO>
        {
            new VillaDTO {Id = 1, Name = "Pool View", Occupancy = 10, Sqft = 100},
            new VillaDTO {Id = 2, Name = "Beach View", Occupancy = 5, Sqft = 50}
        };
    }
}