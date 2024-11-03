using System.Text.Json;
using Entities.DataTransferObjects.Department;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;


namespace Presentation.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly IServiceManager _manager;

    public DepartmentsController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDepartments([FromQuery] DepartmentParameters departmentParameters)
    {
        var departmentsDto = await _manager
            .DepartmentService
            .GetAllDepartments(departmentParameters,false);
        
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(departmentsDto.metaData);
        return Ok(departmentsDto.shapedData);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDepartmentById([FromRoute(Name = "id")] int id)
    {
        var department = await _manager.DepartmentService.GetDepartmentById(id, false);
        
        return Ok(department);
    }
    

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DepartmentDtoForCreate departmentDto)
    {
        var department = await _manager.DepartmentService.CreateDepartment(departmentDto);
        return StatusCode(201, department);
    }

    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDepartment([FromRoute(Name = "id")] int id,
        [FromBody] DepartmentDtoForUpdate departmentDto)
    {
        if (id != departmentDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.DepartmentService.UpdateDepartment(id, departmentDto,true);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.DepartmentService.DeleteDepartment(id,true);
        return NoContent();
    }
    
    
    
    
}