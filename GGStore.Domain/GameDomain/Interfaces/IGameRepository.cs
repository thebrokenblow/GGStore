namespace GGStore.Domain.GameDomain.Interfaces;

public interface IGameRepository
{
    IQueryable<Game> GetAll();
    Task<Game> GetByIdAsync(int id);
    Task<int> AddAsync(GameDto gameDto);
    Task EditAsync(int id, GameDto gameDto);
    Task DeleteAsync(int id);
}