using Entities.DataTransferObjects.Department;
using Entities.DataTransferObjects.Teacher;

namespace Entities.DataTransferObjects.Course;

public record CourseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ShortName { get; init; }
    public int Capacity { get; init; }
    public int MaxCount { get; init; }
    
    public int DepartmentId { get; init; }
    public DepartmentDto Department { get; init; }
    public int TeacherId { get; init; }
    public TeacherDto Teacher { get; init; }
}