namespace Entities.DataTransferObjects.Rank;

public record RankDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ShortName { get; init; }
}