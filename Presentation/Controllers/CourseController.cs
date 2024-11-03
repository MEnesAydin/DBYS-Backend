using System.Text.Json;
using Entities.DataTransferObjects.Course;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CourseController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCourses([FromQuery] CourseParameters courseParameters)
    {
        var coursesDto = await _manager
            .CourseService
            .GetAllCourses(courseParameters,false);
        
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(coursesDto.metaData);
        return Ok(coursesDto.shapedData);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCourseById([FromRoute(Name = "id")] int id)
    {
        var course = await _manager.CourseService.GetCourseById(id, false);
        return Ok(course);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CourseDtoForCreate courseDto)
    {
        var course = await _manager.CourseService.CreateCourse(courseDto);
        return StatusCode(201, course);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCourse([FromRoute(Name = "id")] int id,
        [FromBody] CourseDtoForUpdate courseDto)
    {
        if (id != courseDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.CourseService.UpdateCourse(id, courseDto,true);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.CourseService.DeleteCourse(id,true);
        return NoContent();
    }
}