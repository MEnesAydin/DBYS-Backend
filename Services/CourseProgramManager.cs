using AutoMapper;
using Entities.DataTransferObjects.CourseProgram;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CourseProgramManager : ICourseProgramService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService? _logger;
    private readonly IMapper _mapper;

    public CourseProgramManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<CourseProgram>> GetAllCoursePrograms(bool trackChanges)
    {
        var coursePrograms = await _manager.CourseProgram.GetAllCoursePrograms(trackChanges);
        return coursePrograms;
    }

    public async Task<CourseProgramDto> GetCourseProgram(CourseProgramParameters parameters, bool trackChanges)
    {
        var courseProgram = await _manager.CourseProgram.GetCourseProgram(parameters, trackChanges);
        if (courseProgram is null)
            throw new NotFoundException("istenen program bulunamadı.");
        var courseProgramDto = _mapper.Map<CourseProgramDto>(courseProgram);
        return courseProgramDto;
    }

    public async Task<CourseProgramDto> CreateCourseProgram(CourseProgramDtoForCreate courseProgramDto)
    {
        var courseProgram = _manager.CourseProgram.CreateCourseProgram(_mapper.Map<CourseProgram>(courseProgramDto));
        await _manager.Save();

        return _mapper.Map<CourseProgramDto>(courseProgram);
        
    }

    public async Task DeleteCourseProgram(int id, bool trackChanges)
    {
        var entity = await GetCourseProgramAndCheckExist(id,trackChanges);
        _manager.CourseProgram.DeleteCourseProgram(entity);
        await _manager.Save();
    }
    
    private async Task<CourseProgram> GetCourseProgramAndCheckExist(int id, bool trackChanges)
    {
        var entity = await _manager.CourseProgram.GetCourseProgramById(id, trackChanges);
        if (entity is null)
            throw new NotFoundException("istenen ders programi bulunamadi");
        return entity;
    }
}