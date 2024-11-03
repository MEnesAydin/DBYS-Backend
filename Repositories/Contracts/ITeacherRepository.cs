using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface ITeacherRepository : IRepositoryBase<Teacher>
{
    Task<(List<Teacher> teachers, MetaData metaData)> GetAllFaculties(TeacherParameters teacherParameters,
        bool trackChanges);
    Task<Teacher> GetTeacherById(int id, bool trackChanges);
    Teacher CreateTeacher(Teacher teacher);
    void UpdateTeacher(Teacher teacher);
    void DeleteTeacher(Teacher teacher);
}