using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.ClassRoom;

public record ClassRoomDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public string Name { get; init; }
    [Required(ErrorMessage = "Kapasite alanı boş bırakılamaz.")]
    public int Capacity { get; init; }
    [Required(ErrorMessage = "Sınav kapasitesi alanı boş bırakılamaz.")]
    public int ExamCapacity { get; init; }
    
    public string? PlanUrl { get; init; }

    [Required(ErrorMessage = "Fakülte alanı boş bırakılamaz.")]
    public int FacultyId { get; init; }
}