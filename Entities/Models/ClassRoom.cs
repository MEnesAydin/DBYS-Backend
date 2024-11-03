namespace Entities.Models;

public class ClassRoom : BaseClass
{
    public string? Name { get; set; }
    public int Capacity { get; set; }
    public int ExamCapacity { get; set; }
    public string? PlanUrl { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}