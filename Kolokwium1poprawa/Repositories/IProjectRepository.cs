using Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.Repositories;

public interface IProjectRepository
{
    Task<PreservationProject> GetProjectByIdAsync(CancellationToken cancellationToken, int id);
    Task<bool> IfProjectExistsAsync(int id,CancellationToken cancellationToken);
    Task CreateProject(PreservationProject project, CancellationToken cancellationToken);
}