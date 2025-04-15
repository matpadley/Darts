using DartsScorer.Main.Match.x01;
using DartsScorer.Main.Player;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DartsScorer.Web.Services;

public class MongoX01Service : IX01Service
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Match> _matchCollection;

    public MongoX01Service(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        var databaseName = configuration["MongoDB:DatabaseName"];
        _database = _mongoClient.GetDatabase(databaseName);
        _matchCollection = _database.GetCollection<Match>("x01_matches");
    }

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

        match.AddPlayer(new X01Player(playerName, match.RequiredScore));
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
        var player = match.CurrentPlayer as X01Player;

        player.Throw(throwValue);

        match.UpdatePlayer(player);
        _matchCollection.ReplaceOne(m => m.Id == match.Id, match);
    }
}