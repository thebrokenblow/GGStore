using GGStore.Domain.GameDomain.Interfaces;

namespace GGStore.Domain.GameDomain;

public class GameService(IGameRepository gameRepository) : IGameService
{
    public Task<int> AddAsync(GameDto gameDto) =>
        gameRepository.AddAsync(gameDto);

    public Task DeleteAsync(int id) =>
        gameRepository.DeleteAsync(id);

    public Task EditAsync(int id, GameDto gameDto) =>
        gameRepository.EditAsync(id, gameDto);

    public IEnumerable<Game> GetAll() =>
        gameRepository.GetAll();

    public Task<Game> GetByIdAsync(int id) =>
         gameRepository.GetByIdAsync(id);
}