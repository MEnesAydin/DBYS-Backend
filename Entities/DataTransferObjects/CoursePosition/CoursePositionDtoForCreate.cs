namespace Entities.DataTransferObjects.CoursePosition;

public class CoursePositionDtoForCreate
{
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Count { get; set; }
    
    public int CourseId { get; set; }
    public int ClassRoomId { get; set; }
}