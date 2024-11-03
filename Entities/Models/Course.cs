using Entities.Models;

namespace DerslikBilgiSistemi.Entity;

public class Course : BaseClass
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public int Capacity { get; set; }
    public int MaxCount { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
}