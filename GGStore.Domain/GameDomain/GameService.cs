using AutoMapper;
using AutoMapper.QueryableExtensions;
using GGStore.Domain.GameDomain.Interfaces;

namespace GGStore.Domain.GameDomain;

public class GameService(IMapper mapper, IGameRepository gameRepository) : IGameService
{
    public Task<int> AddAsync(GameDto gameDto) =>
        gameRepository.AddAsync(gameDto);

    public Task DeleteAsync(int id) =>
        gameRepository.DeleteAsync(id);

    public Task EditAsync(int id, GameDto gameDto) =>
        gameRepository.EditAsync(id, gameDto);

    public IEnumerable<GameVM> GetAll() =>
        gameRepository.GetAll().ProjectTo<GameVM>(mapper.ConfigurationProvider);

    public async Task<GameDetailsVM> GetByIdAsync(int id)
    {
        var game = await gameRepository.GetByIdAsync(id);
        var gameVM = mapper.Map<GameDetailsVM>(game);

        return gameVM;
    }
}