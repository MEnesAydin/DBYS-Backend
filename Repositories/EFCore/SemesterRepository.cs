using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class SemesterRepository : RepositoryBase<Semester>, ISemesterRepository
{
    public SemesterRepository(RepositoryContext context) : base(context)
    {
    }


    public async Task<List<Semester>> GetAllSemesters(bool trackChanges)
    {
        var query = await FindAll(trackChanges)
            .OrderBy(s => s.Id)
            .ToListAsync();
        return query;
    }

    public Semester CreateSemester(Semester semester) => Create(semester);

}
    