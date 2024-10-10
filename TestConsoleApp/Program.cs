using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.ReadLine();

async Task DeleteGameByIdAsync(int id)
{
    var responseDelete = await new HttpClient().DeleteAsync($"https://localhost:7292/Game/{id}");
}

async Task PostGameAsync()
{
    var gameDto = new GameDto
    {
        Title = "Batman",
        Description = "Джокер опять сбежал",
        IdGenres = [1, 2],
        Publisher = "Sony",
        DateRelease = new DateOnly(2009, 10, 10)
    };

    var gameJson = JsonSerializer.Serialize(gameDto);
    var requestContent = new StringContent(gameJson, Encoding.UTF8, "application/json");
    var response = await new HttpClient().PostAsync($"https://localhost:7292/Game", requestContent);
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();
}

async Task PutGameByIdAsync(int id)
{
    var gameDto = new GameDto
    {
        Title = "Batman",
        Description = "Джокер опять сбежал",
        IdGenres = [1, 2],
        Publisher = "Sony",
        DateRelease = new DateOnly(2009, 10, 10)
    };

    var gameJson = JsonSerializer.Serialize(gameDto);
    var requestContent = new StringContent(gameJson, Encoding.UTF8, "application/json");
    var response = await new HttpClient().PutAsync($"https://localhost:7292/Game?id={id}", requestContent);
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();
}

async Task GetGameByIdAsync(int id)
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync($"https://localhost:7292/Game/{id}");
    string content = await response.Content.ReadAsStringAsync();
    var gameModel = JsonSerializer.Deserialize<GameModel>(content);
    Console.WriteLine(gameModel);
}

async Task GetGamesAsync()
{
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync("https://localhost:7292/Game");
    string content = await response.Content.ReadAsStringAsync();
    var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content);

    if (gamesModel is not null)
    {
        foreach (var gameModel in gamesModel)
        {
            Console.WriteLine(gameModel);
        }
    }
}

public class GameDto
{
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required List<int> IdGenres { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly DateRelease { get; set; }
}

class GameModel
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("publisher")]
    public required string Publisher { get; set; }

    [JsonPropertyName("dateRelease")]
    public required DateOnly DateRelease { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Title: {Title}, Description: {Description}, Publisher: {Publisher}, DateRelease: {DateRelease.ToString("D")}";
}