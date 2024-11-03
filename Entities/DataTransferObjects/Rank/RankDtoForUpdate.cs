using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Rank;

public record RankDtoForUpdate
{
    [Required(ErrorMessage = "Id alanı bış bırakılamaz.")]
    public int Id { get; init; }
    [Required(ErrorMessage = "İsim alanı bış bırakılamaz.")]
    public string Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı bış bırakılamaz.")]
    public string ShortName { get; init; }
}