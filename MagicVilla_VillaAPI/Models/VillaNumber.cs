using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models;

public class VillaNumber
{
    [Required]
    public int VillaNo { get; set; }

    [Required]
    public int VillaId { get; set; }
    
    public string SpecialDetails { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}