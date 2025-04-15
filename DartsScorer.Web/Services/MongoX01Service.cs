using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Player;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DartsScorer.Web.Services;

/// <summary>
/// Service for managing X01 matches using MongoDB.
/// </summary>
/// <remarks>
/// This service provides methods to create, retrieve, and update X01 matches.
/// </remarks>
public class MongoX01Service : IX01Service
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Match> _matchCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoX01Service"/> class.
    /// </summary>
    /// <param name="mongoClient">The MongoDB client.</param>
    /// <param name="configuration">The application configuration.</param>
    public MongoX01Service(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
        _matchCollection = _database.GetCollection<Match>("x01_matches");
    }

    /// <summary>
    /// Creates a new X01 match or resets an existing one.
    /// </summary>
    /// <param name="requiredScore">The required score to win the match.</param>
    /// <param name="reset">Indicates whether to reset the match.</param>
    /// <returns>The created or reset match.</returns>
    public Match Create(int requiredScore, bool reset)
    {
        if (reset)
        {
            _matchCollection.DeleteMany(FilterDefinition<Match>.Empty);
            var newMatch = new Match(requiredScore);
            _matchCollection.InsertOne(newMatch);
            return newMatch;
        }

        var existingMatch = _matchCollection.Find(FilterDefinition<Match>.Empty).FirstOrDefault();

        if (existingMatch != null)
        {
            return existingMatch;
        }

        var match = new Match(requiredScore);
        _matchCollection.InsertOne(match);
        return match;
    }

    /// <summary>
    /// Retrieves the current X01 match.
    /// </summary>
    /// <returns>The current match, or null if no match exists.</returns>
    public Match Get()
    {
        return _matchCollection.Find(FilterDefinition<Match>.Empty).FirstOrDefault();
    }

    /// <summary>
    /// Adds a player to the current X01 match.
    /// </summary>
    /// <param name="playerName">The name of the player to add.</param>
    public void AddPlayer(string playerName)
    {
        var match = Get();

        if (match.Players.Any(f => f.Name == playerName))
        {
            return;
        }

        match.AddPlayer(new X01Player(playerName, match.RequiredScore));
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }

    /// <summary>
    /// Starts the current X01 match.
    /// </summary>
    /// <returns>The updated match after starting.</returns>
    public Match StartMatch()
    {
        var match = Get();
        match.StartMatch();
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
        return match;
    }

    /// <summary>
    /// Processes a throw for the current player in the X01 match.
    /// </summary>
    /// <param name="throwValue">The value of the throw.</param>
    public void Throw(string throwValue)
    {
        var match = Get();
        var player = match.CurrentPlayer as X01Player;

        player.Throw(throwValue);

        match.UpdatePlayer(player);
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }
}