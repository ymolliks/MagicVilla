using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class UpdateVillaDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30, ErrorMessage = "The name can't be longer than 30 characters")]
        public string Name { get; set; }

        [Required]
        public int Occupancy { get; set; }

        [Required]
        public int Sqft { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string Amenity { get; set; }

        [Required]
        public float Rate { get; set; }
    }
}