using System.Text.Json.Serialization;

namespace Entities.Models;

public class Faculty : BaseClass
{
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    
    public ICollection<ClassRoom> ClassRooms { get; set; }
    public ICollection<Department> Departments { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    
}