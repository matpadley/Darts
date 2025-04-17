using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using DartsScorer.Web.Services.Development;

namespace DartsScorer.Web.Services;

/// <summary>
/// Service for managing Round The Board matches using MongoDB.
/// </summary>
/// <remarks>
/// This service provides methods to create, retrieve, and update Round The Board matches.
/// </remarks>
public class MongoRoundTheBoardService : IRoundTheBoardService
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Match> _matchCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoRoundTheBoardService"/> class.
    /// </summary>
    /// <param name="mongoClient">The MongoDB client.</param>
    /// <param name="configuration">The application configuration.</param>
    public MongoRoundTheBoardService(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
        _matchCollection = _database.GetCollection<Match>("round_the_board_matches");
    }

    /// <summary>
    /// Creates a new Round The Board match or resets an existing one.
    /// </summary>
    /// <param name="reset">Indicates whether to reset the match.</param>
    /// <returns>The created or reset match.</returns>
    public Match Create(bool reset)
    {
        if (reset)
        {
            _matchCollection.DeleteMany(FilterDefinition<Match>.Empty);
            var newMatch = new Match();
            _matchCollection.InsertOne(newMatch);
            return newMatch;
        }

        var existingMatch = _matchCollection.Find(FilterDefinition<Match>.Empty).FirstOrDefault();

        if (existingMatch != null)
        {
            return existingMatch;
        }

        var match = new Match();
        _matchCollection.InsertOne(match);
        return match;
    }

    /// <summary>
    /// Retrieves the current Round The Board match.
    /// </summary>
    /// <returns>The current match, or null if no match exists.</returns>
    public Match Get()
    {
        return _matchCollection.Find(FilterDefinition<Match>.Empty).FirstOrDefault();
    }

    /// <summary>
    /// Adds a player to the current Round The Board match.
    /// </summary>
    /// <param name="playerName">The name of the player to add.</param>
    public void AddPlayer(string playerName)
    {
        var match = Get();

        if (match.Players.Any(f => f.Name == playerName))
        {
            return;
        }

        match.AddPlayer(new RoundTheBoardPlayer(playerName));
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }

    /// <summary>
    /// Starts the current Round The Board match.
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
    /// Processes a throw for the current player in the Round The Board match.
    /// </summary>
    /// <param name="throwValue">The value of the throw.</param>
    public void Throw(string throwValue)
    {
        var match = Get();
        var player = match.CurrentPlayer as RoundTheBoardPlayer;

        player.Throw(throwValue);

        match.UpdatePlayer(player);
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }
}