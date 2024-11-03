using DerslikBilgiSistemi.Entity;

namespace Entities.Models;

public class CoursePosition
{
    public int Id { get; set; }
    public int Day { get; set; }
    public int Hour { get; set; }
    public int Count { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; }

    public int CourseProgramId { get; set; }
    public CourseProgram CourseProgram { get; set; }
}
