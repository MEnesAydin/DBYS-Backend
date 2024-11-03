using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Rank;

public record RankDtoForCreate
{
    [Required(ErrorMessage = "İsim alanı bış bırakılamaz.")]
    public string Name { get; init; }
    [Required(ErrorMessage = "Kısa isim alanı bış bırakılamaz.")]
    public string ShortName { get; init; }
}