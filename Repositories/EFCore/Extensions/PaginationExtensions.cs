using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.EFCore.Extensions;

public static class PaginationExtensions
{
    public static (IQueryable<T> Items, MetaData MetaData) Pagination<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var items = source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        
        var metaData = new MetaData()
        {
            TotalCount = source.Count(),
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPage = (int)Math.Ceiling(source.Count() / (double)pageSize)
        };

        return (Items: items, MetaData: metaData);
    }
}