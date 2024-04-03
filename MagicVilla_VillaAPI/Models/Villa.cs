using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Sqft { get; set; }
        
        public int Occupancy { get; set; }
        
        public string Details { get; set; }
        
        public double? Rate { get; set; }
        
        public string ImageURL { get; set; }
        
        public string Amenity { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
    }
}