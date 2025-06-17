using Kolokwium1poprawa.DTOs;
using Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.Repositories;

public interface IArtifactRepository
{
    Task<ArtifactGetDTO> GetArtifactByIdAsync(CancellationToken cancellationToken, int id);
    Task CreateArtifact(Artifact artifact, CancellationToken cancellationToken);
}