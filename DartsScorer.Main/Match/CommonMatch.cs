using DartsScorer.Main.Exceptions;
using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match;

public abstract class CommonMatch
{
    public bool IsMatchComplete => Players.Count(f => f.Finished()) == 1;
    public MatchPlayer Winner => Players.FirstOrDefault(f => f.Finished());
    public abstract DartsMatchType DartsMatchType { get; }

    private  List<Player.MatchPlayer> _players = [];
    
    public abstract string Name { get; }

    public abstract void StartMatch();

    public IReadOnlyList<MatchPlayer> Players => _players.AsReadOnly();
    
    public bool MatchInProgress { get; set; }

    public Player.Player? CurrentPlayer { get; private set; }

    public void AddPlayer(Player.MatchPlayer player)
    {
        if (player == null)
        {
            throw new PlayerOperationException("Cannot add null player");
        }
        
        if (MatchInProgress)
        {
            throw new MatchOperationException("Cannot add player while match is in progress");
        }

        // Check for duplicate player names
        if (_players.Any(p => p.Name == player.Name))
        {
            throw new PlayerOperationException($"Player with name '{player.Name}' already exists");
        }

        _players.Add(player);
    }

    protected bool CanStartMatch()
    {
        if (Players.Count == 0)
        {
            throw new MatchOperationException("Cannot start match with no players");
        }

        SetCurrentPlayer(Players[0]);

        return true;
    }
    
    
    public void UpdatePlayer(Player.MatchPlayer player)
    {
        if (player == null)
        {
            throw new PlayerOperationException("Cannot update null player");
        }
        
        if (!MatchInProgress)
        {
            throw new MatchOperationException("Cannot update player when match is not in progress");
        }
        
        var currentInd = _players.FindIndex(p => Equals(p, player));
        if (currentInd == -1)
        {
            throw new PlayerOperationException($"Player '{player.Name}' not found in match");
        }
        
        var updatedPlayers = new List<Player.MatchPlayer>(_players)
        {
            [currentInd] = player
        };
        
        _players = updatedPlayers;

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
        if (player == null)
        {
            throw new PlayerOperationException("Cannot set null current player");
        }
        
        CurrentPlayer = player;
    }
}
