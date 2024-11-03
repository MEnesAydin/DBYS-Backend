using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Extensions;

public static class DepartmentRepositoryExtensions
{
    public static IQueryable<Department> Search(this IQueryable<Department> query, 
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return query
            .Where(d => d.Name
                .ToLower()
                .Contains(lowerCaseTerm));
    }

    public static IQueryable<Department> Includes(this IQueryable<Department> query,
        string includes)
    {
        if (string.IsNullOrWhiteSpace(includes))
            return query;
       
        foreach (string include in includes.Split(','))
        {
            switch (include.Trim())
            {
                case "faculty":
                    query = query.Include(d => d.Faculty);
                    break;
            }
        }
        return query;
    }
}