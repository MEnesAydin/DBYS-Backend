using AutoMapper;
using Entities.DataTransferObjects.Semester;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class SemesterManager : ISemesterService
{
    
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;
    private ISemesterService _semesterServiceImplementation;

    public SemesterManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<SemesterDto>> GetAllSemesters(bool trackChanges)
    {
        var semesters = await _manager.Semester.GetAllSemesters(trackChanges);
        var semestersDto = _mapper.Map<List<SemesterDto>>(semesters);
        return semestersDto;
    }

    public async Task<SemesterDto> CreateSemester(SemesterDtoForCreate semesterDto)
    {
        var semester = _manager.Semester.CreateSemester(_mapper.Map<Semester>(semesterDto));
        await _manager.Save();

        return _mapper.Map<SemesterDto>(semester);
    }
}