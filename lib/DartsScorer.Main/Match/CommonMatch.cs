using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public DartsMatchType DartsMatchType { get; set; }

    private  List<Player.MatchPlayer> _players = new();
    
    public abstract string Name { get; }

    public IReadOnlyList<Player.MatchPlayer> Players => _players.AsReadOnly();

    private List<Set> _sets = [];

    public IReadOnlyList<Set> Sets => _sets.AsReadOnly();

    public Set CurrentSet = new();

    public void AddPlayer(Player.MatchPlayer player)
    {
        _players.Add(player);
    }

    public void StartMatch()
    {
        // throw exception if no players
        if (_players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        CurrentPlayer = _players[0];
    }
    
    // hpdate the current player with the one with the updates numbers
    public void UpdatePlayer(Player.MatchPlayer player)
    {
        var currentInd = _players.FindIndex(p => Equals(p, player));
        if (currentInd != -1)
        {
            // Create a temporary list to store the updated players
            var updatedPlayers = new List<Player.MatchPlayer>(_players);
        
            // Replace the player at the found index with the new player
            updatedPlayers[currentInd] = player;
        
            // Replace the original list with the updated list
            _players = updatedPlayers;
        }

        // Get the next player
        var nextInd = currentInd + 1;
        if (nextInd < _players.Count)
        {
            CurrentPlayer = _players[nextInd];
        }
    }

    public Player.Player? CurrentPlayer { get; private set; }
}
