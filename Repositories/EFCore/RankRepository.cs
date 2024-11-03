using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class RankRepository : RepositoryBase<Rank>,IRankRepository
{
    public RankRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<(List<Rank> ranks, MetaData metaData)> GetAllRanks(RankParameters rankParameters, bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(r => r.Id)
            .Where(r => r.IsActive == true)
            .Search(rankParameters.SearchTerm)
            .Pagination(rankParameters.PageNumber, rankParameters.PageSize);

        MetaData metaData = query.MetaData;
        var ranks = await query.Items.ToListAsync();
        return (ranks, metaData);
    }

    public async Task<Rank> GetRankById(int id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


    public Rank CreateRank(Rank rank) => Create(rank);

    public void UpdateRank(Rank rank) => Update(rank);

    public void DeleteRank(Rank rank) => Delete(rank);

}