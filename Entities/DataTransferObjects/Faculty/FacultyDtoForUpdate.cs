using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Faculty;

public record FacultyDtoForUpdate
{
    [Required(ErrorMessage = "Id alanı boş bırakılamaz")]
    public int Id { get; init; }
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
    public string? Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz")]
    public string? ShortName { get; init; }
}