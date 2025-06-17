using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium1poprawa.Models;

public class Artifact
{
    [Key]
    public int ArtifactId { get; set; }
    
    [Required, MaxLength(150)]
    public string Name { get; set; }
    
    [Required]
    public DateTime OriginDate { get; set; }
    
    [Required, ForeignKey("Institution")]
    public int InstitutionId { get; set; }
}