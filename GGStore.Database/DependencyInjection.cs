using GGStore.Domain.GameDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GGStore.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GGStore.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GGStoreDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("GGStoreDbConnection")));

        services.AddTransient<IGameRepository, GameRepository>();

        return services;
    }
}