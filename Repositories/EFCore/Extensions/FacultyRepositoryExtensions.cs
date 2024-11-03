using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.EFCore.Extensions;

public static class FacultyRepositoryExtensions
{
    public static IQueryable<Faculty> Search(this IQueryable<Faculty> faculties, 
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return faculties;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return faculties
            .Where(b => b.Name
                .ToLower()
                .Contains(lowerCaseTerm));
    }
    
    
}