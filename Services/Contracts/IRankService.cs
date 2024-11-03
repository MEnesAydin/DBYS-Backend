using System.Dynamic;
using Entities.DataTransferObjects.Rank;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IRankService
{
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllRanks(RankParameters rankParameters,bool trackChanges);
    Task<RankDto> GetRankById(int id, bool trackChanges);
    Task<RankDto> CreateRank(RankDtoForCreate rankDto);
    Task UpdateRank(int id, RankDtoForUpdate rankDto, bool trackChanges);
    Task DeleteRank(int id, bool trackChanges);
}