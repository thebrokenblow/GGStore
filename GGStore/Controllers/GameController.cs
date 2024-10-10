using GGStore.Domain.GameDomain;
using GGStore.Domain.GameDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GGStore.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController(IGameService gameService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<GameVM>> Get()
    {
        var games = gameService.GetAll();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDetailsVM>> GetDetails(int id)
    {
        var game = await gameService.GetByIdAsync(id);
        return Ok(game);
    }

    [HttpPost(Name = "AddGame")]
    public async Task<ActionResult<int>> AddGame([FromBody] GameDto gameDto)
    {
        var idGame = await gameService.AddAsync(gameDto);
        return Ok(idGame);
    }

    [HttpPut(Name = "EditGame")]
    public async Task<ActionResult> EditGame(int id, [FromBody] GameDto gameDto)
    {
        await gameService.EditAsync(id, gameDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGame(int id)
    {
        await gameService.DeleteAsync(id);
        return NoContent();
    }
}