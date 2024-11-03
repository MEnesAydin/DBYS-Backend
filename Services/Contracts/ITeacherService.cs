using System.Dynamic;
using Entities.DataTransferObjects.Teacher;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface ITeacherService
{
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllTeachers(TeacherParameters teacherParameters,
        bool trackChanges);
    Task<TeacherDto> GetTeacherById(int id,bool trackChanges);
    Task<TeacherDto> CreateTeacher(TeacherDtoForCreate teacherDto);
    Task UpdateTeacher(int id, TeacherDtoForUpdate teacherDto, bool trackChanges);
    Task DeleteTeacher(int id, bool trackChanges);
}