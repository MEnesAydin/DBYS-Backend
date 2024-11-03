using Entities.DataTransferObjects.Faculty;

namespace Entities.DataTransferObjects.ClassRoom;

public record ClassRoomDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int Capacity { get; init; }
    public int ExamCapacity { get; init; }
    public string? PlanUrl { get; init; }

    public int FacultyId { get; init; }
    public FacultyDto? Faculty { get; init; }
}