namespace Entities.Models;

public class Semester
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateOnly Date { get; set; }

    public ICollection<CourseProgram> CoursePrograms { get; set; }
    
}