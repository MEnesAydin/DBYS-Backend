using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IRankRepository : IRepositoryBase<Rank>
{
    Task<(List<Rank> ranks, MetaData metaData)> GetAllRanks(RankParameters rankParameters,
        bool trackChanges);
    Task<Rank> GetRankById(int id, bool trackChanges);
    Rank CreateRank(Rank rank);
    void UpdateRank(Rank rank);
    void DeleteRank(Rank rank);
}