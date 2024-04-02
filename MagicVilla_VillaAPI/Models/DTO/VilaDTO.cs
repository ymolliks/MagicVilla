using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30, ErrorMessage = "The name can't be longer than 30 characters")]
        public string Name { get; set; }

        public int Occupancy { get; set; }

        public int Sqft { get; set; }
        
        public string ImageURL { get; set; }
        
        public string Amenity { get; set; }
    }
}