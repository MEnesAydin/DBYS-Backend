using System.Dynamic;
using System.Text.Json;
using Entities.DataTransferObjects.ClassRoom;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/classRooms")]
public class ClassRoomController : ControllerBase
{
    private readonly IServiceManager _manager;

    public ClassRoomController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClassRooms([FromQuery] ClassRoomParameters classRoomParameters)
    {
        var classRoomsDto = await _manager
            .ClassRoomService
            .GetAllClassRooms(classRoomParameters, false);
        
        Response.Headers["X-Pagination"] = JsonSerializer.Serialize(classRoomsDto.MetaData);
        return Ok(classRoomsDto.shapedData);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetClassRoomById([FromRoute(Name = "id")] int id)
    {
        var classRoom = await _manager.ClassRoomService.GetClassRoomById(id, false);
        return Ok(classRoom);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClassRoomDtoForCreate classRoomDto)
    {
        var classRoom = await _manager.ClassRoomService.CreateClassRoom(classRoomDto);
        return StatusCode(201, classRoom);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateClassRoom([FromRoute(Name = "id")] int id,
        [FromBody] ClassRoomDtoForUpdate classRoomDto)
    {
        if (id != classRoomDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.ClassRoomService.UpdateClassRoom(id, classRoomDto,true);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.ClassRoomService.DeleteClassRoom(id,true);
        return NoContent();
    }
}