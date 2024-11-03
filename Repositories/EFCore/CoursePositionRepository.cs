using DerslikBilgiSistemi.Entity;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class CoursePositionRepository : RepositoryBase<CoursePosition>,ICoursePositionRepository
{
    public CoursePositionRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<CoursePosition?> GetCoursePositionById(int id, bool trackChanges) =>
        await FindByCondition(cp => cp.Id.Equals(id), trackChanges)
            .Include(cp => cp.ClassRoom)
            .Include(cp => cp.Course)
            .ThenInclude(c => c.Teacher)
            .ThenInclude(t => t.Rank)
            .Include(cp => cp.Course)
            .ThenInclude(c => c.Department)
            .SingleOrDefaultAsync();

}