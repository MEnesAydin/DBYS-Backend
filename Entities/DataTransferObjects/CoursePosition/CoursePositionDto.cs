namespace Entities.DataTransferObjects.CoursePosition;

public record CoursePositionDto
{
    public int Id { get; init; }
    public string? CourseShortName { get; init; }
    public int Day { get; init; }
    public int Hour { get; init; }
    public int Count { get; init; }
    public int CourseId { get; init; }
    public int DepartmentId { get; init; }
    public int ClassRoomId { get; init; }
}