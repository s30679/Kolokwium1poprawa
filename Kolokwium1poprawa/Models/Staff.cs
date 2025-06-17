using System.ComponentModel.DataAnnotations;

namespace Kolokwium1poprawa.Models;

public class Staff
{
    [Key]
    public int StaffId { get; set; }
    
    [Required, MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required, MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime HireDate { get; set; }
}