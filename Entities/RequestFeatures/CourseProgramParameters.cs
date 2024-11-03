using System.Text.Json.Serialization;

namespace Entities.RequestFeatures;

public record CourseProgramParameters
{
    public int Id { get; init; }
    public DateOnly Date { get; init; }
    public int FacultyID { get; init; }
}