using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.Semester;

public record SemesterDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string? Name { get; init; }
    [Required(ErrorMessage = "Tarih alanı boş bırakılamaz.")]
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; init; }
}