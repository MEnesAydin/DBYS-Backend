using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Faculty;

public record FacultyDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
    public string? Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz")]
    public string? ShortName { get; init; }
}