using System.Text.Json.Serialization;
using Entities.DataTransferObjects.CoursePosition;

namespace Entities.DataTransferObjects.CourseProgram;

public record CourseProgramDto
{
    public int Id { get; init; }
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; init; }
    public int SemesterId { get; init; }
    public List<CoursePositionDto> CoursePositions { get; init; }
}