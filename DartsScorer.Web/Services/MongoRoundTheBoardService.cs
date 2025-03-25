using DartsScorer.Main.Match.RoundTheBoard;
using DartsScorer.Main.Player;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using DartsScorer.Web.Services.Development;

namespace DartsScorer.Web.Services;

public class MongoRoundTheBoardService : IRoundTheBoardService
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Match> _matchCollection;

    public MongoRoundTheBoardService(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
        _matchCollection = _database.GetCollection<Match>("round_the_board_matches");
    }

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

    public Match Get()
    {
        return _matchCollection.Find(FilterDefinition<Match>.Empty).FirstOrDefault();
    }

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

    public Match StartMatch()
    {
        var match = Get();
        match.StartMatch();
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
        return match;
    }

    public void Throw(string throwValue)
    {
        var match = Get();
        var player = match.CurrentPlayer as RoundTheBoardPlayer;

        player.Throw(throwValue);

        match.UpdatePlayer(player);
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }
}