using DerslikBilgiSistemi.Entity;
using Entities.Models;

namespace Repositories.Contracts;

public interface ICoursePositionRepository : IRepositoryBase<CoursePosition>
{
    Task<CoursePosition?> GetCoursePositionById(int id, bool trackChanges);
}