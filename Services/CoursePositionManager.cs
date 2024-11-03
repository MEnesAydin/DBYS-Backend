using AutoMapper;
using DerslikBilgiSistemi.Entity;
using Entities.DataTransferObjects.CoursePosition;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CoursePositionManager : ICoursePositionService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public CoursePositionManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<CoursePositionWithDetailsDto> GetCoursePositionById(int id, bool trackChanges)
    {
        var coursePosition = await GetCoursePositionAndCheckExist(id, trackChanges);
        var coursePositionDto = _mapper.Map<CoursePositionWithDetailsDto>(coursePosition);
        return coursePositionDto;
    }

    private async Task<CoursePosition> GetCoursePositionAndCheckExist(int id, bool trackChanges)
    {
        var coursePosition = await _manager.CoursePosition.GetCoursePositionById(id, trackChanges);
        if (coursePosition is null)
            throw new NotFoundException("Kurs pozisyonu bulunamadı");
        return coursePosition;
    }
}