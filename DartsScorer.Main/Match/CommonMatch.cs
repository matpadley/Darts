using DartsScorer.Main.Player;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("IsMatchComplete")]
    public bool IsMatchComplete => Players.Count(f => f.Finished()) == 1;

    [BsonElement("Winner")]
    public MatchPlayer Winner => Players.FirstOrDefault(f => f.Finished())!;

    [BsonElement("DartsMatchType")]
    public abstract DartsMatchType DartsMatchType { get; }

    [BsonIgnore]
    private List<MatchPlayer> _players = new();
    
    [BsonElement("Name")]
    public abstract string Name { get; }

    [BsonElement("MatchInProgress")]
    public bool MatchInProgress { get; set; }

    [BsonElement("CurrentPlayer")]
    public Player.Player? CurrentPlayer { get; private set; }

    [BsonElement("Players")]
    public IReadOnlyList<MatchPlayer> Players => _players.AsReadOnly();

    public abstract void StartMatch();

    public bool HasPlayer(string playerName)
    {
        return _players.Any(p => p.Name == playerName);
    }
    
    public int PlayerCount => _players.Count;

    public void AddPlayer(Player.MatchPlayer player)
    {
        _players.Add(player);
    }

    protected bool CanStartMatch()
    {
        if (Players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        SetCurrentPlayer(Players[0]);

        return true;
    }
    
    
    public void UpdatePlayer(Player.MatchPlayer player)
    {
        var currentInd = _players.FindIndex(p => Equals(p, player));
        if (currentInd != -1)
        {
            var updatedPlayers = new List<Player.MatchPlayer>(_players)
            {
                [currentInd] = player
            };
            
            _players = updatedPlayers;
        }

        if (player.Finished())
        {
            return;
        }

        if (player.CurrentLeg != null && !player.CurrentLeg.IsComplete) return;
        
        // Get the next player
        var nextInd = currentInd + 1 == _players.Count ? 0 : currentInd + 1;
        
        if (nextInd < _players.Count)
        {
            CurrentPlayer = _players[nextInd];
        }
    }

    protected void SetCurrentPlayer(Player.Player player)
    {
        CurrentPlayer = player;
    }
}
