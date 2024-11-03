using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects.Rank;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class RankManager : IRankService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService? _logger;
    private readonly IMapper _mapper;

    public RankManager(IRepositoryManager manager, ILoggerService? logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllRanks(RankParameters rankParameters, bool trackChanges)
    {
        var ranks = await _manager
            .Rank
            .GetAllRanks(rankParameters, trackChanges);

        var ranksDto = _mapper.Map<IEnumerable<RankDto>>(ranks.ranks);

        var shapedData = DataShaper.ShapeData(ranksDto, rankParameters.Fields, typeof(RankDto));
        return (shapedData, ranks.metaData);
    }

    public async Task<RankDto> GetRankById(int id, bool trackChanges)
    {
        var rank = await GetRankAndCheckExists(id, trackChanges);
        return _mapper.Map<RankDto>(rank);
    }

    public async Task<RankDto> CreateRank(RankDtoForCreate rankDto)
    {
        var rank = _manager.Rank.CreateRank(_mapper.Map<Rank>(rankDto));
        await _manager.Save();

        return _mapper.Map<RankDto>(rank);
    }

    public async Task UpdateRank(int id, RankDtoForUpdate rankDto, bool trackChanges)
    {
        var rank = await _manager.Rank.GetRankById(id, trackChanges);
        _mapper.Map(rankDto, rank);
        await _manager.Save();
    }

    public async Task DeleteRank(int id, bool trackChanges)
    {
        var rank = await GetRankAndCheckExists(id, trackChanges);
        rank.IsActive = false;
        await _manager.Save();
    }
    
    private async Task<Rank> GetRankAndCheckExists(int id, bool trackChanges)
    {
        var entity = await _manager.Rank.GetRankById(id, trackChanges);
        if (entity is null)
            throw new NotFoundException("istenen ünvan bulunamadı");
        return entity;
    }
}