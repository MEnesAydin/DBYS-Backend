using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface ICourseProgramRepository : IRepositoryBase<CourseProgram>
{
    Task<List<CourseProgram>> GetAllCoursePrograms(bool trackChanges);
    Task<CourseProgram> GetCourseProgram(CourseProgramParameters parameters, bool trackChanges);
    CourseProgram CreateCourseProgram(CourseProgram courseProgram);
    Task<CourseProgram?> GetCourseProgramById(int id, bool trackChanges);
    void DeleteCourseProgram(CourseProgram courseProgram);
}