using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Course;

public record CourseDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz.")]
    public string ShortName { get; init; }
    [Required(ErrorMessage = "Kapasite alanı boş bırakılamaz.")]
    public int Capacity { get; init; }
    [Required(ErrorMessage ="Ders sayısı alanı boş bırakılamaz")]
    public int MaxCount { get; set; }
    [Required(ErrorMessage = "Departman alanı boş bırakılamaz.")]
    public int DepartmentId { get; init; }
    [Required(ErrorMessage = "Öğretmen alanı boş bırakılamaz.")]
    public int TeacherId { get; init; }
}