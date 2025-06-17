using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium1poprawa.Models;

public class PreservationProject
{
    [Key]
    public int ProjectId { get; set; }
    
    [ForeignKey("ArtifactId")]
    public int ArtifactId { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    [Required, MaxLength(200)]
    public string Objective { get; set; }
}