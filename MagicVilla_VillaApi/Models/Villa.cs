using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaApi.Models;

public class Villa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Details { get; set; }

    [Required] public double rate { get; set; }

    [Required] public int sqft { get; set; }

    [Required] public bool occupancy { get; set; }

    public string imageurl { get; set; }

    public string amenity { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }
}