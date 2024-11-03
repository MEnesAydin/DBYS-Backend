using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IClassRoomService ClassRoomService { get; }
        ICourseService CourseService { get; }
        ICoursePositionService CoursePositionService { get; }
        ICourseProgramService CourseProgramService { get; }
        IDepartmentService DepartmentService { get; }
        IFacultyService FacultyService { get; }
        IRankService RankService { get; }
        ITeacherService TeacherService { get; }
        ISemesterService SemesterService { get; }
      }
}