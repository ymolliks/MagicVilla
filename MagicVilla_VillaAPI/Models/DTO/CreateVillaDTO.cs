using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class CreateVillaDTO
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The name can't be longer than 30 characters")]
        public string Name { get; set; }

        [Required]
        public int Occupancy { get; set; }

        [Required]
        public int Sqft { get; set; }

        [Required]
        public string Details { get; set; }

        public string ImageURL { get; set; }

        public string Amenity { get; set; }

        public float Rate { get; set; }
    }
}