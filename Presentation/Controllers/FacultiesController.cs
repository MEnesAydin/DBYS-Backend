using Entities.DataTransferObjects.Faculty;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Presentation.Controllers;

[ServiceFilter(typeof(LogFilterAttribute))]
[ApiController]
[Route("api/faculties")]
public class FacultiesController : ControllerBase
{
    private readonly IServiceManager _manager;

    public FacultiesController(IServiceManager manager)
    {
        _manager = manager;
    }

    /// <summary>
    /// Tüm fakülteleri çeker
    /// </summary>
    /// <param name="facultyParameters"></param>
    /// <returns></returns>
    //[Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllFaculties([FromQuery] FacultyParameters facultyParameters)
    {
        var facultiesDto = await _manager
            .FacultyService
            .GetAllFaculties(facultyParameters,false);
        
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(facultiesDto.metaData);

        return Ok(facultiesDto.shapedData);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFacultyById([FromRoute(Name = "id")] int id)
    {
        var faculty = await _manager
            .FacultyService
            .GetFacultyById(id, false);
        return Ok(faculty);
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FacultyDtoForCreate facultyDto)
    {
        var entity = await _manager.FacultyService.CreateFaculty(facultyDto);
        return StatusCode(201,entity);
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateFaculty([FromRoute(Name = "id")] int id,
        [FromBody] FacultyDtoForUpdate facultyDto)
    {
        if (id != facultyDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.FacultyService.UpdateFaculty(id,facultyDto,true);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.FacultyService.DeleteFaculty(id,true);
        return NoContent();
    }
    /*
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateFaculty([FromRoute(Name = "id")] int id,
        [FromBody] JsonPatchDocument<FacultyDtoForUpdate> facultyPatch)
    {
        var result = await _manager.FacultyService.GetFacultyForPatch(id, true);
        facultyPatch.ApplyTo(result.facultyDtoForUpdate, ModelState);
        TryValidateModel(result.facultyDtoForUpdate);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        
        await _manager.FacultyService.SaveChangesForPatch(result.facultyDtoForUpdate,result.faculty);
        return NoContent();
    }
    
    */
    
}