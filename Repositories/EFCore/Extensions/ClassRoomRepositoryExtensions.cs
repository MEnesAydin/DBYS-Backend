using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Extensions;

public static class ClassRoomRepositoryExtensions
{
    public static IQueryable<ClassRoom> Search(this IQueryable<ClassRoom> query, 
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
    
    public static IQueryable<ClassRoom> Includes(this IQueryable<ClassRoom> query,
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