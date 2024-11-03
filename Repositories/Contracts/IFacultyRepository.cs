using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IFacultyRepository : IRepositoryBase<Faculty>
{
    Task<(List<Faculty> faculties, MetaData metaData)> GetAllFaculties(FacultyParameters facultyParameters,
        bool trackChanges);
    Task<Faculty?> GetFacultyById(int id, bool trackChanges);
    Faculty CreateFaculty(Faculty faculty);
    void UpdateFaculty(Faculty faculty);
    void DeleteFaculty(Faculty faculty);
}