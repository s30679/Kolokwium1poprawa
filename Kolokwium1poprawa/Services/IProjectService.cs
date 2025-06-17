using Kolokwium1poprawa.DTOs;

namespace Kolokwium1poprawa.Services;

public interface IProjectService
{
    Task<GetResponseDTO?> GetProjectsAsync(CancellationToken cancellationToken, int id);

    Task<bool> AddArtifactWithProjectAsync(CreateArtifactWithProjectDTO artifactProjectDTO, CancellationToken cancellationToken);
}