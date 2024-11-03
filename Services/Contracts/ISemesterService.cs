using Entities.DataTransferObjects.Semester;
using Entities.Models;

namespace Services.Contracts;

public interface ISemesterService
{
    Task<List<SemesterDto>> GetAllSemesters(bool trackChanges);
    Task<SemesterDto> CreateSemester(SemesterDtoForCreate semester);
}