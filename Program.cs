
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBossService>(new LocalBossService());
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEverything",
    builder => {
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("AllowEverything");

app.MapGet("/bosses", (IBossService service) => service.GetBosses());

app.MapGet("/bosses/{id}", Results<Ok<Boss>, NotFound> (string id, IBossService service) =>
{
    var targetBoss = service.GetBossById(id);
    return targetBoss is null
        ? TypedResults.NotFound()
        : TypedResults.Ok(targetBoss);
});

app.Run();

public record Boss(int series, string id, string name, string weapon, string avatar, string sprite1, string weakness, string stageImg);

interface IBossService
{
    Boss? GetBossById(string id);
    List<Boss> GetBosses();
}

class LocalBossService : IBossService
{
    private readonly List<Boss>? _bosses = JsonSerializer.Deserialize<List<Boss>>(File.ReadAllText("bosses.json"),
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    public Boss? GetBossById(string id)
    {
        return _bosses?.SingleOrDefault(boss => int.Parse(id) == int.Parse(boss.id));
    }

    public List<Boss> GetBosses()
    {    
         return _bosses is null ? [] : _bosses;
    }
}