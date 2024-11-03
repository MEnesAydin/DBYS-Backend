using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects.Teacher;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class TeacherManager : ITeacherService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public TeacherManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllTeachers(TeacherParameters teacherParameters, bool trackChanges)
    {
        var teachers = await _manager
            .Teacher
            .GetAllFaculties(teacherParameters, trackChanges);
        
        var teachersDto = _mapper.Map<List<TeacherDto>>(teachers.teachers);
        
        var shapedData = DataShaper.ShapeData(teachersDto,teacherParameters.Fields,typeof(TeacherDto));

        return (shapedData, teachers.metaData);
    }

    public async Task<TeacherDto> GetTeacherById(int id, bool trackChanges)
    {
        var teacher = await GetTeacherAndCheckExists(id, trackChanges);
        var teacherDto = _mapper.Map<TeacherDto>(teacher);
        return teacherDto;
    }

    public async Task<TeacherDto> CreateTeacher(TeacherDtoForCreate teacherDto)
    {
        var teacher = _manager.Teacher.CreateTeacher(_mapper.Map<Teacher>(teacherDto));
        await _manager.Save();
        
        return _mapper.Map<TeacherDto>(teacher);
    }

    public async Task UpdateTeacher(int id, TeacherDtoForUpdate teacherDto, bool trackChanges)
    {
        var teacher = await GetTeacherAndCheckExists(id, trackChanges);
        _mapper.Map(teacherDto, teacher);
        await _manager.Save();
    }

    public async Task DeleteTeacher(int id, bool trackChanges)
    {
        var teacher = await GetTeacherAndCheckExists(id, trackChanges);
        teacher.IsActive = false;
        await _manager.Save();
    }
    
    private async Task<Teacher> GetTeacherAndCheckExists(int id, bool trackChanges)
    {
        var teacher = await _manager.Teacher.GetTeacherById(id, trackChanges);
        if (teacher is null)
            throw new NotFoundException("istenen öğretmen bulunamadı.");
        return teacher;
    }
}