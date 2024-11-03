using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects.Faculty;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class FacultyManager : IFacultyService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService? _logger;
    private readonly IMapper _mapper;

    public FacultyManager(IRepositoryManager manager, ILoggerService logger,IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllFaculties(FacultyParameters facultyParameters, bool trackChanges)
    {
        var faculties = await _manager
            .Faculty
            .GetAllFaculties(facultyParameters, trackChanges);
        var facultiesDto = _mapper.Map<IEnumerable<FacultyDto>>(faculties.faculties);

        var shapedData = DataShaper.ShapeData(facultiesDto, facultyParameters.Fields, typeof(FacultyDto));
        return (shapedData, faculties.metaData);
    }



    public async Task<FacultyDto> GetFacultyById(int id, bool trackChanges)
    {
        var faculty = await GetFacultyAndCheckExists(id, trackChanges);
        return _mapper.Map<FacultyDto>(faculty);
    }

    public async Task<FacultyDto> CreateFaculty(FacultyDtoForCreate facultyDto)
    {
        var faculty = _manager.Faculty.CreateFaculty(_mapper.Map<Faculty>(facultyDto));
        await _manager.Save();

        return _mapper.Map<FacultyDto>(faculty);
    }

    public async Task UpdateFaculty(int id, FacultyDtoForUpdate facultyDto, bool trackChanges)
    {
        var faculty = await GetFacultyAndCheckExists(id, trackChanges);
        //entity = facultyDto.Adapt<Faculty>();
        _mapper.Map(facultyDto, faculty);
        //_manager.Faculty.UpdateFaculty(entity);
        await _manager.Save();
    }

    public async Task DeleteFaculty(int id, bool trackChanges)
    {
        var faculty = await GetFacultyAndCheckExists(id, trackChanges);
        faculty.IsActive = false;
        await _manager.Save();
    }

    public async Task<(FacultyDtoForUpdate facultyDtoForUpdate, Faculty faculty)> GetFacultyForPatch(int id, bool trackChanges)
    {
        var faculty = await GetFacultyAndCheckExists(id, trackChanges);
        var facultyDto = _mapper.Map<FacultyDtoForUpdate>(faculty);
        return (facultyDto, faculty);
    }

    public async Task SaveChangesForPatch(FacultyDtoForUpdate facultyDtoForUpdate, Faculty faculty)
    {
        _mapper.Map(facultyDtoForUpdate, faculty);
        //_manager.Faculty.UpdateFaculty(faculty);
        await _manager.Save();   
    }

    private async Task<Faculty> GetFacultyAndCheckExists(int id, bool trackChanges)
    {
        var entity = await _manager.Faculty.GetFacultyById(id, trackChanges);
        if (entity is null)
            throw new NotFoundException("istenen fakülte bulunamadı");
        return entity;
    }
}