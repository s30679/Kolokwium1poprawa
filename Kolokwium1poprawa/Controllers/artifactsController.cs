using Kolokwium1poprawa.DTOs;
using Kolokwium1poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1poprawa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class artifactsController
{
    private readonly IProjectService _projectService;

    public artifactsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddArtifactWithProjectAsync([FromBody] CreateArtifactWithProjectDTO artifactWithProjectDto, CancellationToken cancellationToken)
    {
        var pole=await _projectService.AddArtifactWithProjectAsync(artifactWithProjectDto, cancellationToken);
        if (pole == null)
        {
            return BadRequest("Taki projekt nie istnieje");
        }
        return Created("",null);
    }
}