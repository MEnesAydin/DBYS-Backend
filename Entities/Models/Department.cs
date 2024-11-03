using DerslikBilgiSistemi.Entity;

namespace Entities.Models;

public class Department : BaseClass
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? Color { get; set; }
    
    public int FacultyId { get; set; }
    public  Faculty Faculty { get; set; }

    public ICollection<Course> Courses { get; set; }
}