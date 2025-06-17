using Kolokwium1poprawa.Repositories;
using Kolokwium1poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1poprawa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class projectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public projectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectsAsync(CancellationToken cancellationToken, int id)
    {
        var response=await _projectService.GetProjectsAsync(cancellationToken, id);
        if (response == null)
        {
            return NotFound("Projekt o taki ID nie istnieje!");
        }
        return Ok(response);
    }
}