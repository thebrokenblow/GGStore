using AutoMapper;
using GGStore.Domain.GenreDomain;

namespace GGStore.Domain.Mapping;

public class MappingGenre : Profile
{
    public MappingGenre()
    {
        CreateMap<Genre, GenreVM>();
    }
}
