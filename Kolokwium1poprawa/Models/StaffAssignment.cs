using System.ComponentModel.DataAnnotations;

namespace Kolokwium1poprawa.Models;

public class StaffAssignment
{
    
    public int StaffId { get; set; }
    
    public int ProjectId { get; set; }
    
    [Required, MaxLength(50)]
    public string Role { get; set; }
}