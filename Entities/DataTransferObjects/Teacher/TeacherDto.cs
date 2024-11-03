using Entities.DataTransferObjects.Faculty;
using Entities.DataTransferObjects.Rank;

namespace Entities.DataTransferObjects.Teacher;

public record TeacherDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ShortName { get; init; }

    public int FacultyId { get; init; }
    public FacultyDto? Faculty { get; init; }
    public int RankId { get; init; }
    public RankDto? Rank { get; init; }
}