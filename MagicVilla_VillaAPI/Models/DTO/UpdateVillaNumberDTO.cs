using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO;

public class UpdateVillaNumberDTO
{
    [Required]
    public int VillaNo { get; set; }

    public string SpecialDetails { get; set; }
}