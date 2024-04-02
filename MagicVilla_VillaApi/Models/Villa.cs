using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaApi.Models;

public class Villa
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string MyProperty { get; set; }
    
    //create datetime
    
    public DateTime CreatedDate { get; set; }
}