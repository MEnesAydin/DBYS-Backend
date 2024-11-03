using Entities.DataTransferObjects.Semester;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/semesters")]
public class SemesterController : ControllerBase
{
    private readonly IServiceManager _manager;

    public SemesterController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSemesters()
    {
        var semesters = await _manager.SemesterService.GetAllSemesters(false);
        return Ok(semesters);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SemesterDtoForCreate semesterDto)
    {
        var entity = await _manager.SemesterService.CreateSemester(semesterDto);
        return StatusCode(201,entity);
    }
}