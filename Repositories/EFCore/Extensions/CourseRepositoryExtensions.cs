using DerslikBilgiSistemi.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Extensions;

public static class CourseRepositoryExtensions
{
    public static IQueryable<Course> Search(this IQueryable<Course> query, 
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return query
            .Where(c => 
                c.Name.ToLower().Contains(lowerCaseTerm) ||
                c.ShortName.ToLower().Contains(lowerCaseTerm));
    }
    
    public static IQueryable<Course> Includes(this IQueryable<Course> query,
        string includes)
    {
        if (string.IsNullOrWhiteSpace(includes))
            return query;
       
        foreach (string include in includes.Split(','))
        {
            switch (include.Trim())
            {
                case "department":
                    query = query.Include(c => c.Department);
                    break;
                case "teacher":
                    query = query
                        .Include(c => c.Teacher)
                        .ThenInclude(t => t.Rank);
                    break;
            }
        }
        return query;
    }
}