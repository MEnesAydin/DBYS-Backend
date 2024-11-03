using Repositories.Contracts;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    
    private readonly Lazy<IClassRoomRepository> _classRoomRepository;
    private readonly Lazy<ICourseProgramRepository> _courseProgramRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<ICoursePositionRepository> _coursePositionRepository;
    private readonly Lazy<IFacultyRepository> _facultyRepository;
    private readonly Lazy<IRankRepository> _rankRepository;
    private readonly Lazy<IDepartmentRepository> _departmentRepository;
    private readonly Lazy<ISemesterRepository> _semesterRepository;
    private readonly Lazy<ITeacherRepository> _teacherRepository;
    
    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _classRoomRepository = new Lazy<IClassRoomRepository>(() => new ClassRoomRepository(_context));
        _courseProgramRepository = new Lazy<ICourseProgramRepository>(() => new CourseProgramRepository(_context));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_context));
        _coursePositionRepository = new Lazy<ICoursePositionRepository>(() => new CoursePositionRepository(_context));
        _facultyRepository = new Lazy<IFacultyRepository>(() => new FacultyRepository(_context));
        _rankRepository = new Lazy<IRankRepository>(() => new RankRepository(_context));
        _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_context));
        _semesterRepository = new Lazy<ISemesterRepository>(() => new SemesterRepository(_context));
        _teacherRepository = new Lazy<ITeacherRepository>(() => new TeacherRepository(_context));
    }

    public IClassRoomRepository ClassRoom => _classRoomRepository.Value;
    public ICourseProgramRepository CourseProgram => _courseProgramRepository.Value;
    public ICourseRepository Course => _courseRepository.Value;
    public ICoursePositionRepository CoursePosition => _coursePositionRepository.Value;
    public IFacultyRepository Faculty => _facultyRepository.Value;
    public IRankRepository Rank => _rankRepository.Value;
    public IDepartmentRepository Department => _departmentRepository.Value;
    public ISemesterRepository Semester => _semesterRepository.Value;
    public ITeacherRepository Teacher => _teacherRepository.Value;

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}