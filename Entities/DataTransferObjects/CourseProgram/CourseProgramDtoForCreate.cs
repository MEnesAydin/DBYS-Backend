using System.Text.Json.Serialization;
using Entities.DataTransferObjects.CoursePosition;

namespace Entities.DataTransferObjects.CourseProgram;

public record CourseProgramDtoForCreate
{
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; init; }
    public int SemesterId { get; init; }
    public List<CoursePositionDtoForCreate> CoursePositions { get; init; }
}