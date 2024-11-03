using Repositories.Contracts;
using Services.Contracts;
using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClassRoomService> _classRoomService;
        private readonly Lazy<ICourseService> _courseService;
        private readonly Lazy<ICoursePositionService> _coursePositionService;
        private readonly Lazy<ICourseProgramService> _courseProgramService; 
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IFacultyService> _facultyService;
        private readonly Lazy<IRankService> _rankService;
        private readonly Lazy<ISemesterService> _semesterService;
        private readonly Lazy<ITeacherService> _teacherService;
        
        
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration)

        {
            _classRoomService = new Lazy<IClassRoomService>(() => new ClassRoomManager(repositoryManager, logger, mapper));
            _courseService = new Lazy<ICourseService>(() => new CourseManager(repositoryManager, logger, mapper));
            _coursePositionService =
                new Lazy<ICoursePositionService>(() => new CoursePositionManager(repositoryManager, logger, mapper));
            _courseProgramService =
                new Lazy<ICourseProgramService>(() => new CourseProgramManager(repositoryManager, logger, mapper));
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentManager(repositoryManager,logger,mapper));
            _facultyService = new Lazy<IFacultyService>(() => new FacultyManager(repositoryManager,logger,mapper));
            _rankService = new Lazy<IRankService>(() => new RankManager(repositoryManager, logger, mapper));
            _semesterService = new Lazy<ISemesterService>(() => new SemesterManager(repositoryManager, logger, mapper));
            _teacherService = new Lazy<ITeacherService>(() => new TeacherManager(repositoryManager, logger, mapper));
            
            }

        public IClassRoomService ClassRoomService => _classRoomService.Value;
        public ICourseService CourseService => _courseService.Value;
        public ICoursePositionService CoursePositionService => _coursePositionService.Value;
        public ICourseProgramService CourseProgramService => _courseProgramService.Value;
        public IDepartmentService DepartmentService => _departmentService.Value; 
        public IFacultyService FacultyService => _facultyService.Value;
        public IRankService RankService => _rankService.Value;
        public ISemesterService SemesterService => _semesterService.Value;
        public ITeacherService TeacherService => _teacherService.Value;
    }
}