using DartsScorer.Main.Player;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using DartsScorer.Web.Services.Development;

namespace DartsScorer.Web.Services;

/// <summary>
/// Service for managing players using MongoDB.
/// </summary>
/// <remarks>
/// This service provides methods to add, delete, edit, and retrieve players.
/// </remarks>
public class MongoPlayerService : IPlayerService
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoPlayerService"/> class.
    /// </summary>
    /// <param name="mongoClient">The MongoDB client.</param>
    /// <param name="configuration">The application configuration.</param>
    public MongoPlayerService(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
    }

    /// <summary>
    /// Retrieves all players.
    /// </summary>
    /// <returns>A list of players.</returns>
    public IList<Player>? GetPlayers()
    {
        var collection = _database.GetCollection<Player>("players");
        return collection.Find(FilterDefinition<Player>.Empty).ToList();
    }

    /// <summary>
    /// Adds a new player.
    /// </summary>
    /// <param name="name">The name of the player to add.</param>
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

    /// <summary>
    /// Deletes a player by name.
    /// </summary>
    /// <param name="name">The name of the player to delete.</param>
    public void Delete(string name)
    {
        var collection = _database.GetCollection<Player>("players");

        var deleteResult = collection.DeleteOne(player => player.Name == name);

        if (deleteResult.DeletedCount == 0)
        {
            throw new InvalidOperationException($"No player with the name '{name}' was found to delete.");
        }
    }

    /// <summary>
    /// Edits a player's name.
    /// </summary>
    /// <param name="oldName">The current name of the player.</param>
    /// <param name="name">The new name of the player.</param>
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

    /// <summary>
    /// Retrieves players for a dropdown list.
    /// </summary>
    /// <returns>A list of players formatted for a dropdown.</returns>
    public IList<SelectListItem> GetPlayersForDropDown()
    {
        var players = GetPlayers();
        return players?.Select(player => new SelectListItem(player.Name, player.Name)).ToList() ?? new List<SelectListItem>();
    }

    /// <summary>
    /// Checks if a player exists by name.
    /// </summary>
    /// <param name="name">The name of the player to check.</param>
    /// <returns>True if the player exists, otherwise false.</returns>
    public bool CheckPlayerExists(string name)
    {
        var players = GetPlayers();
        return players != null && players.Any(player => player.Name == name);
    }
}