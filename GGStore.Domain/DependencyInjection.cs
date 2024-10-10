using AutoMapper;
using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using GGStore.Domain.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GGStore.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var mappingProfiles = new List<Profile>
        {
            new MappingGame(),
            new MappingGenre()
        };

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfiles(mappingProfiles);
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddSingleton(new CreateGameValidation());

        services.AddTransient<IGameService, GameService>();

        return services;
    }
}
