using Entities.Models;

namespace Repositories.Contracts;

public interface ISemesterRepository : IRepositoryBase<Semester>
{
    Task<List<Semester>> GetAllSemesters(bool trackChanges);
    Semester CreateSemester(Semester semester);
}