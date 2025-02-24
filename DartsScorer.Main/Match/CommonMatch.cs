using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public abstract bool IsMatchComplete { get; }
    public DartsMatchType DartsMatchType { get; protected init; }

    private  List<Player.MatchPlayer> _players = [];
    
    public abstract string Name { get; }

    public IReadOnlyList<Player.MatchPlayer> Players => _players.AsReadOnly();

    private readonly List<Set> _sets = [];

    public IReadOnlyList<Set> Sets => _sets.AsReadOnly();
    
    public abstract bool MatchInProgress { get; set; }

    public void AddPlayer(Player.MatchPlayer player)
    {
        _players.Add(player);
    }

    public abstract void StartMatch();

    protected bool CanStartMatch()
    {
        // throw exception if no players
        if (Players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        SetCurrentPlayer(Players[0]);

        return true;
    }
    
    // update the current player with the one with the updates numbers
    public void UpdatePlayer(Player.MatchPlayer player)
    {
        var currentInd = _players.FindIndex(p => Equals(p, player));
        if (currentInd != -1)
        {
            // Create a temporary list to store the updated players
            var updatedPlayers = new List<Player.MatchPlayer>(_players)
            {
                // Replace the player at the found index with the new player
                [currentInd] = player
            };

            // Replace the original list with the updated list
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

    public Player.Player? CurrentPlayer { get; private set; }

    protected void SetCurrentPlayer(Player.Player player)
    {
        CurrentPlayer = player;
    }
}
