namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IClassRoomRepository ClassRoom { get; }
    ICourseProgramRepository CourseProgram { get; }
    ICourseRepository Course { get; }
    ICoursePositionRepository CoursePosition { get; }
    IDepartmentRepository Department { get; }
    IFacultyRepository Faculty { get;  }
    IRankRepository Rank { get; }
    ISemesterRepository Semester { get;  }
    ITeacherRepository Teacher { get; }
    
    
    Task Save();
}