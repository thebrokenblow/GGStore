using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GGStore.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController(IGameService gameService)
{
    [HttpGet]
    public IEnumerable<Game> Get() =>
        gameService.GetAll();

    [HttpGet("{id}")]
    public async Task<Game> GetDetails(int id) =>
        await gameService.GetByIdAsync(id);

    [HttpPost(Name = "AddGame")]
    public async Task<int> AddGame([FromBody] GameDto gameDto) =>
       await gameService.AddAsync(gameDto);

    [HttpPut(Name = "EditGame")]
    public async Task EditGame(int id, [FromBody] GameDto gameDto) =>
      await gameService.EditAsync(id, gameDto);

    [HttpDelete("{id}")]
    public async Task DeleteGame(int id) =>
        await gameService.DeleteAsync(id);
}