using Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.DTOs;

public class ArtifactGetDTO
{
    public string name { get; set; }
    public DateTime originDate { get; set; }
    public Institution institution { get; set; }   
}