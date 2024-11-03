using System.Dynamic;
using Entities.DataTransferObjects.Course;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface ICourseService
{
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllCourses(CourseParameters courseParameters,
        bool trackChanges);
    Task<CourseDto> GetCourseById(int id,bool trackChanges);
    Task<CourseDto> CreateCourse(CourseDtoForCreate courseDto);
    Task UpdateCourse(int id, CourseDtoForUpdate courseDto, bool trackChanges);
    Task DeleteCourse(int id, bool trackChanges);
}