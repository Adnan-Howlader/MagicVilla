using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaApi.Models.DTO;

public class VillaCreateDTO
{
   

    public string Name { get; set; }

    public string Details { get; set; }

    [Required] public double rate { get; set; }

    [Required] public int sqft { get; set; }

    [Required] public bool occupancy { get; set; }

    public string imageurl { get; set; }

    public string amenity { get; set; }

    
}