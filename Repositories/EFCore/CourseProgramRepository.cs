using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class CourseProgramRepository : RepositoryBase<CourseProgram>,ICourseProgramRepository
{
    private ICourseProgramRepository _courseProgramRepositoryImplementation;

    public CourseProgramRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<List<CourseProgram>> GetAllCoursePrograms(bool trackChanges)
    {
        var coursePrograms = await FindAll(trackChanges).ToListAsync();
        return coursePrograms;
    }

    public async Task<CourseProgram?> GetCourseProgram(CourseProgramParameters parameters,bool trackChanges)
    {
        return await _context.CoursePrograms
            .DateFilter(parameters)
            .Include(cp => cp.CoursePositions)
            .ThenInclude(c => c.Course)
            .ThenInclude(c => c.Department)
            .IdFilter(parameters.Id)
            .FacultyFilter(parameters.FacultyID)
            .FirstOrDefaultAsync();
    }

    public async Task<CourseProgram?> GetCourseProgramById(int id, bool trackChanges) =>
        await FindByCondition(cp => cp.Id == id, trackChanges)
            .FirstOrDefaultAsync();

    
    public CourseProgram CreateCourseProgram(CourseProgram courseProgram) => Create(courseProgram);

    public void DeleteCourseProgram(CourseProgram courseProgram) => Delete(courseProgram);
}