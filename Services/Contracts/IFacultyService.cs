using System.Dynamic;
using Entities.DataTransferObjects.Faculty;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IFacultyService
{
    /// <summary>
    /// tüm fakülteleri çeker
    /// </summary>
    /// <param name="facultyParameters"></param>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllFaculties(FacultyParameters facultyParameters,bool trackChanges);
    Task<FacultyDto> GetFacultyById(int id, bool trackChanges);
    Task<FacultyDto> CreateFaculty(FacultyDtoForCreate facultyDto);
    Task UpdateFaculty(int id, FacultyDtoForUpdate facultyDto, bool trackChanges);
    Task DeleteFaculty(int id, bool trackChanges);
    Task<(FacultyDtoForUpdate facultyDtoForUpdate, Faculty faculty)> GetFacultyForPatch(int id, bool trackChanges);
    Task SaveChangesForPatch(FacultyDtoForUpdate facultyDtoForUpdate, Faculty faculty);
}