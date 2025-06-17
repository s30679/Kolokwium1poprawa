namespace Kolokwium1poprawa.DTOs;

public class ProjectDTO
{
    public int projectId { get; set; }
    public string objective { get; set; }
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
}