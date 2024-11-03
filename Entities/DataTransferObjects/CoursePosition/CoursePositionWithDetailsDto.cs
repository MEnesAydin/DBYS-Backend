using Entities.DataTransferObjects.ClassRoom;
using Entities.DataTransferObjects.Course;

namespace Entities.DataTransferObjects.CoursePosition;

public record CoursePositionWithDetailsDto
{
    public int Id { get; init; }
    public int Day { get; init; }
    public int Hour { get; init; }
    public int Count { get; set; }
    public CourseDto? Course { get; init; }
    public ClassRoomDto? ClassRoom { get; init; }
}