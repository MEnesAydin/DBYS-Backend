using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Extensions;

public static class TeacherRepositoryExtensions
{
    public static IQueryable<Teacher> Search(this IQueryable<Teacher> query, 
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
    
    public static IQueryable<Teacher> Includes(this IQueryable<Teacher> query,
        string includes)
    {
        if (string.IsNullOrWhiteSpace(includes))
            return query;
       
        foreach (string include in includes.Split(','))
        {
            switch (include.Trim())
            {
                case "faculty":
                    query = query.Include(r => r.Faculty);
                    break;
                case "rank":
                    query = query.Include(t => t.Rank);
                    break;
            }
        }
        return query;
    }
}