using Entities.DataTransferObjects.CourseProgram;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface ICourseProgramService
{
    Task<List<CourseProgram>> GetAllCoursePrograms(bool trackChanges);
    Task<CourseProgramDto> GetCourseProgram(CourseProgramParameters parameters, bool trackChanges);
    Task<CourseProgramDto> CreateCourseProgram(CourseProgramDtoForCreate courseProgramDto);
    Task DeleteCourseProgram(int id, bool trackChanges);
}