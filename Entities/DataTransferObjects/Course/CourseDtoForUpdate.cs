using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Course;

public class CourseDtoForUpdate
{
    [Required(ErrorMessage = "Id alanı boş bırakılamaz.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Kısa isim alanı boş bırakılamaz.")]
    public string ShortName { get; set; }
    [Required(ErrorMessage = "Kapasite alanı boş bırakılamaz.")]
    public int Capacity { get; set; }
    [Required(ErrorMessage ="Ders sayısı alanı boş bırakılamaz")]
    public int MaxCount { get; set; }
    [Required(ErrorMessage = "Departman alanı boş bırakılamaz.")]
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "Öğretmen alanı boş bırakılamaz.")]
    public int TeacherId { get; set; }
}