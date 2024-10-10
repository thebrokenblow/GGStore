﻿using GGStore.Domain.GenreDomain;

namespace GGStore.Domain.GameDomain;

public class GameDetailsVM
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required List<GenreVM> Genres { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly DateRelease { get; set; }
}