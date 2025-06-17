using Kolokwium1poprawa.Models;

namespace Kolokwium1poprawa.DTOs;

public class CreateArtifactWithProjectDTO
{
    public Artifact Artifact { get; set; }
    public ProjectDTO Project { get; set; }
}