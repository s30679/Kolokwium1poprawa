using Kolokwium1poprawa.DTOs;

namespace Kolokwium1poprawa.Repositories;

public interface IStaffAssignmentRepository
{
    Task<List<StaffAssignmentsGetDTO>> GetStaffAssignmentsByProjectIdAsync(int projectId, CancellationToken cancellationToken);
}