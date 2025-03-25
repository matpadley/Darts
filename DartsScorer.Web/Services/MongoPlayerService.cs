using DartsScorer.Main.Player;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using DartsScorer.Web.Services.Development;

namespace DartsScorer.Web.Services;


public class MongoPlayerService : IPlayerService
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;

    public MongoPlayerService(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
    }

    // Implement other methods for IPlayerService
    public IList<Player>? GetPlayers()
    {
        var collection = _database.GetCollection<Player>("players");
        return collection.Find(FilterDefinition<Player>.Empty).ToList();
    }

    public void Add(string name)
    {
        var collection = _database.GetCollection<Player>("players");

        if (CheckPlayerExists(name))
        {
            throw new InvalidOperationException($"A player with the name '{name}' already exists.");
        }

        var newPlayer = new Player(name);
        collection.InsertOne(newPlayer);
    }

    public void Delete(string name)
    {
        var collection = _database.GetCollection<Player>("players");

        var deleteResult = collection.DeleteOne(player => player.Name == name);

        if (deleteResult.DeletedCount == 0)
        {
            throw new InvalidOperationException($"No player with the name '{name}' was found to delete.");
        }
    }

    public void Edit(string oldName, string name)
    {
        var collection = _database.GetCollection<Player>("players");

        if (CheckPlayerExists(name))
        {
            throw new InvalidOperationException($"A player with the name '{name}' already exists.");
        }

        var updateResult = collection.UpdateOne(
            player => player.Name == oldName,
            Builders<Player>.Update.Set(player => player.Name, name)
        );

        if (updateResult.MatchedCount == 0)
        {
            throw new InvalidOperationException($"No player with the name '{oldName}' was found to update.");
        }
    }

    public IList<SelectListItem> GetPLayersForDropDown()
    {
        var players = GetPlayers();
        return players.Select(player => new SelectListItem(player.Name, player.Name)).ToList();
    }

    public bool CheckPlayerExists(string name)
    {
        var players = GetPlayers();
        return players != null && players.Any(player => player.Name == name);
    }
}