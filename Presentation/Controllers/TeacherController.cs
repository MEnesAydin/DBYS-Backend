using System.Text.Json;
using Entities.DataTransferObjects.Teacher;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeacherController : ControllerBase
{
    private readonly IServiceManager _manager;

    public TeacherController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTeachers([FromQuery] TeacherParameters teacherParameters)
    {
        var teachersDto = await _manager
            .TeacherService
            .GetAllTeachers(teacherParameters,false);
        
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(teachersDto.metaData);
        return Ok(teachersDto.shapedData);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTeacherById([FromRoute(Name = "id")] int id)
    {
        var teacher = await _manager.TeacherService.GetTeacherById(id, false);
        
        return Ok(teacher);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TeacherDtoForCreate teacherDto)
    {
        var teacher = await _manager.TeacherService.CreateTeacher(teacherDto);
        return StatusCode(201, teacher);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTeacher([FromRoute(Name = "id")] int id,
        [FromBody] TeacherDtoForUpdate teacherDto)
    {
        if (id != teacherDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.TeacherService.UpdateTeacher(id, teacherDto,true);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.TeacherService.DeleteTeacher(id,true);
        return NoContent();
    }
}