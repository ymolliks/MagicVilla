using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO;

public class CreateVillaNumberDTO
{
    [Required]
    public int VillaNo { get; set; }

    public string SpecialDetails { get; set; }
}