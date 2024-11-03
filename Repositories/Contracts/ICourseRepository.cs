using DerslikBilgiSistemi.Entity;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface ICourseRepository : IRepositoryBase<Course>
{
    Task<(List<Course> courses, MetaData metaData)> GetAllCourses(CourseParameters courseParameters
        ,bool trackChanges);
    Task<Course> GetCourseById(int id, bool trackChanges);
    Course CreateCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(Course course);
}