namespace Entities.DataTransferObjects.Faculty;

public record FacultyDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? ShortName { get; init; }
}