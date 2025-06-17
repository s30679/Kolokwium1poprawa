using Kolokwium1poprawa.DTOs;
using Kolokwium1poprawa.Models;
using Kolokwium1poprawa.Repositories;

namespace Kolokwium1poprawa.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IArtifactRepository _artifactRepository;
    private readonly IStaffAssignmentRepository _staffAssignmentRepository;
    private readonly string _connectionString;
    public ProjectService(IProjectRepository projectRepository, IArtifactRepository artifactRepository, IStaffAssignmentRepository assignmentRepository, IConfiguration configuration)
    {
        _projectRepository = projectRepository;
        _artifactRepository = artifactRepository;
        _staffAssignmentRepository = assignmentRepository;
        _connectionString = configuration.GetConnectionString("db-mssql");
    }

    public async Task<GetResponseDTO?> GetProjectsAsync(CancellationToken cancellationToken, int id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(cancellationToken, id);
        if (project == null)
        {
            return null;
        }
        var artifact = await _artifactRepository.GetArtifactByIdAsync(cancellationToken, project.ArtifactId);
        var lista = await _staffAssignmentRepository.GetStaffAssignmentsByProjectIdAsync(id,cancellationToken);
        return new GetResponseDTO
        {
            projectId  = id,
            objective = project.Objective,
            startDate = project.StartDate,
            endDate = project.EndDate,
            artifact = artifact,
            staffAssignments = lista
        };
    }

    public async Task<bool> AddArtifactWithProjectAsync(CreateArtifactWithProjectDTO artifactProjectDTO, CancellationToken cancellationToken)
    {
        if (!await _projectRepository.IfProjectExistsAsync(artifactProjectDTO.Project.projectId, cancellationToken))
        {
            return false;
        }
        var artifact = new Artifact
        {
            ArtifactId = artifactProjectDTO.Artifact.ArtifactId,
            Name = artifactProjectDTO.Artifact.Name,
            OriginDate = artifactProjectDTO.Artifact.OriginDate,
            InstitutionId = artifactProjectDTO.Artifact.InstitutionId,
        };
        var project = new PreservationProject
        {
            ProjectId = artifactProjectDTO.Project.projectId,
            ArtifactId = artifactProjectDTO.Artifact.ArtifactId,
            StartDate = artifactProjectDTO.Project.startDate,
            EndDate = artifactProjectDTO.Project.endDate,
            Objective = artifactProjectDTO.Project.objective
        };
        await _projectRepository.CreateProject(project, cancellationToken);
        await _artifactRepository.CreateArtifact(artifact, cancellationToken);
        return true;
    }
}