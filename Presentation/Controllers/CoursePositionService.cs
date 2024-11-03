using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/CoursePositions")]
public class CoursePositionService : ControllerBase
{
    private readonly IServiceManager _manager;

    public CoursePositionService(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCoursePositionById([FromRoute(Name = "id")] int id)
    {
        var coursePositionDto = await _manager.CoursePositionService.GetCoursePositionById(id, false);
        return Ok(coursePositionDto);
    }
    
}