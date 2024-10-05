namespace GGStore.Domain.GameDomain;

public class GameDto
{
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required List<int> IdGenres { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly DateRelease { get; set; }
}