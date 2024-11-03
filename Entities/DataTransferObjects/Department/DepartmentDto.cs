using Entities.DataTransferObjects.Faculty;

namespace Entities.DataTransferObjects.Department;

public record DepartmentDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ShortName { get; init; }
    public string Color { get; init; }
    
    public int FacultyId { get; init; }
    public FacultyDto? Faculty { get; init; }
    
}