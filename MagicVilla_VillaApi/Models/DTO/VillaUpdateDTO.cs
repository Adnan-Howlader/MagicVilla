using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaApi.Models.DTO;

public class VillaUpdateDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Details { get; set; }

    [Required] public double rate { get; set; }

    [Required] public int sqft { get; set; }

    [Required] public bool occupancy { get; set; }

    [Required] public string imageurl { get; set; }

    [Required] public string amenity { get; set; }
    
}