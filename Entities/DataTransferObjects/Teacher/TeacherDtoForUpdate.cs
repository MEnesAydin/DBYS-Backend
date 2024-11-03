using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Teacher;

public record TeacherDtoForUpdate
{
    [Required(ErrorMessage = "Id alanı boş bırakılamaz.")]
    public int Id { get; init; }
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz.")]
    public string ShortName { get; init; }

    [Required(ErrorMessage = "Fakülte alanı boş bırakılamaz.")]
    public int FacultyId { get; init; }
    [Required(ErrorMessage = "Ünvan alanı boş bırakılamaz.")]
    public int RankId { get; init; }
}