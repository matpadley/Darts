using DartsScorer.Main.Exceptions;
using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match;

/// <summary>
/// Base abstract class for all dart game match types.
/// Provides common functionality for managing players, match state, and game flow.
/// </summary>
public abstract class CommonMatch
{
    /// <summary>
    /// Gets a value indicating whether the match is complete.
    /// A match is considered complete when exactly one player has finished.
    /// </summary>
    public bool IsMatchComplete => Players.Count(f => f.Finished()) == 1;
    
    /// <summary>
    /// Gets the winner of the match, or null if no player has finished yet.
    /// </summary>
    public MatchPlayer Winner => Players.FirstOrDefault(f => f.Finished());
    
    /// <summary>
    /// Gets the type of darts match being played.
    /// </summary>
    public abstract DartsMatchType DartsMatchType { get; }

    private  List<Player.MatchPlayer> _players = [];
    
    /// <summary>
    /// Gets the display name of the match type.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Starts the match if there are players registered.
    /// Implementation varies by game type.
    /// </summary>
    public abstract void StartMatch();

    /// <summary>
    /// Gets a read-only list of all players in the match.
    /// </summary>
    public IReadOnlyList<MatchPlayer> Players => _players.AsReadOnly();
    
    /// <summary>
    /// Gets or sets a value indicating whether the match is currently in progress.
    /// </summary>
    public bool MatchInProgress { get; set; }

    /// <summary>
    /// Gets the player whose turn it currently is.
    /// </summary>
    public Player.Player? CurrentPlayer { get; private set; }

    /// <summary>
    /// Adds a player to the match if the match hasn't started yet.
    /// </summary>
    /// <param name="player">The player to add to the match</param>
    /// <exception cref="PlayerOperationException">Thrown when the player is null or a player with the same name already exists</exception>
    /// <exception cref="MatchOperationException">Thrown when attempting to add a player while the match is in progress</exception>
    public void AddPlayer(Player.MatchPlayer player)
    {
        // Using pattern matching with null pattern
        if (player is null)
        {
            throw new PlayerOperationException("Cannot add null player");
        }
        
        // Using pattern matching with logical patterns
        if (MatchInProgress is true)
        {
            throw new MatchOperationException("Cannot add player while match is in progress");
        }

        // Using pattern matching with lambda expression
        if (_players.Any(p => p.Name == player.Name))
        {
            throw new PlayerOperationException($"Player with name '{player.Name}' already exists");
        }

        _players.Add(player);
    }

    /// <summary>
    /// Verifies that the match can be started.
    /// Checks if there are players registered and sets the current player.
    /// </summary>
    /// <returns>true if the match can be started; otherwise, false</returns>
    /// <exception cref="MatchOperationException">Thrown when attempting to start a match with no players</exception>
    protected bool CanStartMatch()
    {
        if (Players.Count == 0)
        {
            throw new MatchOperationException("Cannot start match with no players");
        }

        SetCurrentPlayer(Players[0]);

        return true;
    }
    
    /// <summary>
    /// Updates a player's state in the match and advances to the next player if appropriate.
    /// </summary>
    /// <param name="player">The player to update</param>
    /// <exception cref="PlayerOperationException">Thrown when the player is null or not found in the match</exception>
    /// <exception cref="MatchOperationException">Thrown when attempting to update a player when the match is not in progress</exception>
    public void UpdatePlayer(Player.MatchPlayer player)
    {
        // Using pattern matching with null pattern
        if (player is null)
        {
            throw new PlayerOperationException("Cannot update null player");
        }
        
        // Using pattern matching with negation pattern
        if (MatchInProgress is not true)
        {
            throw new MatchOperationException("Cannot update player when match is not in progress");
        }
        
        var currentInd = _players.FindIndex(p => Equals(p, player));
        
        // Using pattern matching with relational pattern
        if (currentInd is -1)
        {
            throw new PlayerOperationException($"Player '{player.Name}' not found in match");
        }
        
        var updatedPlayers = new List<Player.MatchPlayer>(_players)
        {
            [currentInd] = player
        };
        
        _players = updatedPlayers;

        // Early return if the player has finished
        if (player.Finished())
        {
            return;
        }

        // Using pattern matching with property pattern and logical patterns
        if (player.CurrentLeg is { IsComplete: false }) return;
        
        // Get the next player
        var nextInd = currentInd + 1 == _players.Count ? 0 : currentInd + 1;
        
        // Standard conditional - pattern matching isn't suitable here
        if (nextInd >= 0 && nextInd < _players.Count)
        {
            CurrentPlayer = _players[nextInd];
        }
    }

    /// <summary>
    /// Sets the current active player.
    /// </summary>
    /// <param name="player">The player to set as current</param>
    /// <exception cref="PlayerOperationException">Thrown when the player is null</exception>
    protected void SetCurrentPlayer(Player.Player player)
    {
        // Using pattern matching with null pattern
        if (player is null)
        {
            throw new PlayerOperationException("Cannot set null current player");
        }
        
        CurrentPlayer = player;
    }
}
