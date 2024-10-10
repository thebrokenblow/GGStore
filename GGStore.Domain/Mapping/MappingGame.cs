using AutoMapper;
using GGStore.Domain.GameDomain;

namespace GGStore.Domain.Mapping;

public class MappingGame : Profile
{
    public MappingGame()
    {
        CreateMap<Game, GameDetailsVM>()
           .ForMember(x => x.Title, y => y.MapFrom(x => x.Title))
           .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
           .ForMember(x => x.Genres, y => y.MapFrom(x => x.Genres))
           .ForMember(x => x.Publisher, y => y.MapFrom(x => x.Publisher))
           .ForMember(x => x.DateRelease, y => y.MapFrom(x => x.DateRelease));

        CreateMap<Game, GameVM>()
            .ForMember(x => x.Title, y => y.MapFrom(x => x.Title))
            .ForMember(x => x.Description, y => y.MapFrom(x => x.Description))
            .ForMember(x => x.Publisher, y => y.MapFrom(x => x.Publisher))
            .ForMember(x => x.DateRelease, y => y.MapFrom(x => x.DateRelease));
    }
}