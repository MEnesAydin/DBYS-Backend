using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class FacultyRepository : RepositoryBase<Faculty>, IFacultyRepository
{
    public FacultyRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<(List<Faculty> faculties, MetaData metaData)> GetAllFaculties(FacultyParameters facultyParameters,
        bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(f => f.Id)
            .Where(f => f.IsActive)
            .Search(facultyParameters.SearchTerm)
            .OrderBy(b => b.Id)
            .Pagination(facultyParameters.PageNumber, facultyParameters.PageSize);

        MetaData metaData = query.MetaData;
        var faculties = await query.Item1.ToListAsync();
        return (faculties,metaData);
    }
        

    public async Task<Faculty?> GetFacultyById(int id, bool trackChanges) =>
        await FindByCondition(f => f.Id.Equals(id),trackChanges)
            .SingleOrDefaultAsync();

    public Faculty CreateFaculty(Faculty faculty) => Create(faculty);

    public void UpdateFaculty(Faculty faculty) => Update(faculty);

    public void DeleteFaculty(Faculty faculty) => Delete(faculty);
}