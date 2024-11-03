using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.Semester;

public record SemesterDto
{
    public int Id { get; init; }
    public string? Name { get; set; }
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; set; }
    
}