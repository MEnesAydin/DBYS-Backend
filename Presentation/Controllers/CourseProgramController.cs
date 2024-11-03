using Entities.DataTransferObjects.CourseProgram;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CourseProgramController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CourseProgramController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCoursePrograms()
    {
        var coursePrograms = await _manager.CourseProgramService.GetAllCoursePrograms(false);
        return Ok(coursePrograms);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseProgram([FromQuery] CourseProgramParameters parameters)
    {
        var courseProgram = await _manager.CourseProgramService.GetCourseProgram(parameters, false);
        return Ok(courseProgram);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CourseProgramDtoForCreate courseProgramDto)
    {
        var entity = await _manager.CourseProgramService.CreateCourseProgram(courseProgramDto);
        return StatusCode(201,entity);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.CourseProgramService.DeleteCourseProgram(id, false);
        return NoContent();
    }
}