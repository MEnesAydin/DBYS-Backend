using Entities.Models;

namespace Repositories.EFCore.Extensions;

public static class RankRepositoryEtensions
{
    public static IQueryable<Rank> Search(this IQueryable<Rank> ranks, 
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return ranks;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return ranks
            .Where(b => b.Name
                .ToLower()
                .Contains(lowerCaseTerm));
    }
}