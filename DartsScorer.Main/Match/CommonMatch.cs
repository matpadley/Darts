using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch(MatchConfiguration config)
{
    
    public abstract DartsMatchType DartsMatchType { get; }
    public abstract string Name { get; }
    public abstract void StartMatch();

    private List<MatchPlayer> _players = [];
    public MatchConfiguration Configuration { get; set; } = config;
    public bool IsMatchComplete => Players.Count(f => f.Finished()) == 1;
    public MatchPlayer? Winner => Players.FirstOrDefault(f => f.Finished());
    public IReadOnlyList<MatchPlayer> Players => _players.AsReadOnly();
    public bool MatchInProgress { get; set; }

    public Player.Player? CurrentPlayer { get; private set; }
    
    protected bool CanStartMatch()
    {
        if (Players.Count == 0)
        {
            throw new InvalidOperationException("Cannot start match with no players");
        }

        SetCurrentPlayer(Players[0]);

        return true;
    }
    protected void SetCurrentPlayer(Player.Player player)
    {
        CurrentPlayer = player;
    }
    public void UpdatePlayer(MatchPlayer player)
    {
        var currentInd = _players.FindIndex(p => Equals(p, player));
        if (currentInd != -1)
        {
            var updatedPlayers = new List<MatchPlayer>(_players)
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
    public void AddPlayer(MatchPlayer player)
    {
        _players.Add(player);
    }
}
