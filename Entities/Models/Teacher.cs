using DerslikBilgiSistemi.Entity;

namespace Entities.Models;

public class Teacher : BaseClass
{
    public string Name { get; set; }
    public string ShortName { get; set; }

    public int RankId { get; set; }
    public Rank Rank { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public ICollection<Course> Courses { get; set; }
}