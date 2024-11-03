using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Department;
using Models;

public record DepartmentDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string? Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz.")]
    public string? ShortName { get; init; }
    [Required(ErrorMessage = "Renk alanı boş bırakılamaz.")]
    public string? Color { get; init; }
    [Required(ErrorMessage = "Fakülte alanı boş bırakılamaz.")]
    public int FacultyId { get; init; }
}