using System.Dynamic;
using AutoMapper;
using DerslikBilgiSistemi.Entity;
using Entities.DataTransferObjects.Course;
using Entities.Exceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CourseManager : ICourseService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public CourseManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllCourses(CourseParameters courseParameters, bool trackChanges)
    {
        var courses = await _manager
            .Course
            .GetAllCourses(courseParameters, trackChanges);
        
        var coursesDto = _mapper.Map<List<CourseDto>>(courses.courses);
        
        var shapedData = DataShaper.ShapeData(coursesDto,courseParameters.Fields,typeof(CourseDto));

        return (shapedData, courses.metaData);
    }

    public async Task<CourseDto> GetCourseById(int id, bool trackChanges)
    {
        var course = await GetCourseAndCheckExists(id, trackChanges);
        var courseDto = _mapper.Map<CourseDto>(course);
        return courseDto;
    }

    public async Task<CourseDto> CreateCourse(CourseDtoForCreate courseDto)
    {
        var course = _manager.Course.CreateCourse(_mapper.Map<Course>(courseDto));
        await _manager.Save();
        
        return _mapper.Map<CourseDto>(course);
    }

    public async Task UpdateCourse(int id, CourseDtoForUpdate courseDto, bool trackChanges)
    {
        var course = await GetCourseAndCheckExists(id, trackChanges);
        _mapper.Map(courseDto, course);
        await _manager.Save();
    }

    public async Task DeleteCourse(int id, bool trackChanges)
    {
        var course = await GetCourseAndCheckExists(id, trackChanges);
        course.IsActive = false;
        await _manager.Save();
    }
    
    private async Task<Course> GetCourseAndCheckExists(int id, bool trackChanges)
    {
        var course = await _manager.Course.GetCourseById(id, trackChanges);
        if (course is null)
            throw new NotFoundException("istenen kurs bulunamadı.");
        return course;
    }
}