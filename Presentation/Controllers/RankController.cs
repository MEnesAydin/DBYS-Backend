using System.Dynamic;
using System.Text.Json;
using Entities.DataTransferObjects.Rank;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/ranks")]
public class RankController  : ControllerBase
{
    private readonly IServiceManager _manager;

    public RankController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRanks([FromQuery] RankParameters rankParameters)
    {
        var ranksDto = await _manager
            .RankService
            .GetAllRanks(rankParameters, false);
        Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(ranksDto.metaData));
        return Ok(ranksDto.shapedData);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRankById([FromRoute(Name = "id")] int id)
    {
        var rank = await _manager
            .RankService
            .GetRankById(id, false);
        return Ok(rank);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RankDtoForCreate rankDto)
    {
        var entity = await _manager.RankService.CreateRank(rankDto);
        return StatusCode(201,entity);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRank([FromRoute(Name = "id")] int id,
        [FromBody] RankDtoForUpdate rankDto)
    {
        if (id != rankDto.Id)
            return UnprocessableEntity("Girilen id ile nesnenin id uyuşmuyor.");
        await _manager.RankService.UpdateRank(id,rankDto,true);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
    {
        await _manager.RankService.DeleteRank(id,true);
        return NoContent();
    }
}