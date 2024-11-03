using DerslikBilgiSistemi.Entity;
using Entities.DataTransferObjects.CoursePosition;

namespace Services.Contracts;

public interface ICoursePositionService
{
    Task<CoursePositionWithDetailsDto> GetCoursePositionById(int id, bool trackChanges);
}