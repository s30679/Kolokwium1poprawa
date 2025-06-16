using Kolokwium1poprawa.Repositories;
using Kolokwium1poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1poprawa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Controller : ControllerBase
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken, int id)
    {
        var pole=null;
        if (pole == null)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(CancellationToken cancellationToken)
    {
        var pole=null;
        if (pole == null)
        {
            return BadRequest();
        }
        return Created();
    }
}