using DerslikBilgiSistemi.Entity;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class CourseRepository : RepositoryBase<Course>,ICourseRepository
{
    public CourseRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<(List<Course> courses, MetaData metaData)> GetAllCourses(CourseParameters courseParameters, bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .Where(c => c.IsActive == true)
            .Search(courseParameters.SearchTerm)
            .Includes(courseParameters.Includes)
            .Pagination(courseParameters.PageNumber, courseParameters.PageSize);

        MetaData metaData = query.MetaData;
        var courses = await query.Items.ToListAsync();

        return (courses, metaData);
    }

    public async Task<Course> GetCourseById(int id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(c => c.Department)
            .Include(c => c.Teacher)
            .SingleOrDefaultAsync();

    public Course CreateCourse(Course course) => Create(course);

    public void UpdateCourse(Course course) => Update(course);

    public void DeleteCourse(Course course) => Delete(course);

}