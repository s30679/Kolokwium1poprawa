using System.ComponentModel.DataAnnotations;

namespace Kolokwium1poprawa.Models;

public class Institution
{
    [Key]
    public int institutionId { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int FoundedYear { get; set; }
}