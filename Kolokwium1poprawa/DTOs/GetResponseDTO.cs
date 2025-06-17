namespace Kolokwium1poprawa.DTOs;

public class GetResponseDTO
{
    public int projectId { get; set; }
    public string objective { get; set; }
    public DateTime startDate { get; set; }
    public DateTime? endDate { get; set; }
    public ArtifactGetDTO artifact { get; set; }
    public List<StaffAssignmentsGetDTO> staffAssignments { get; set; }
}