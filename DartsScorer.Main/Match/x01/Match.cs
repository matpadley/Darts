using DartsScorer.Main.Player;

namespace DartsScorer.Main.Match.x01;

/// <summary>
/// Implements the X01 variant of darts, commonly played as 301, 501, etc.
/// Players start with a specified score (X01) and attempt to reduce it to exactly zero,
/// typically finishing on a double.
/// </summary>
public sealed class Match : CommonMatch
{
    /// <summary>
    /// Gets the display name of the match type.
    /// </summary>
    public override string Name => "x01";
    
    /// <summary>
    /// Gets the required score for this match (301, 501, etc.).
    /// </summary>
    public int RequiredScore { get; private set; }
    
    /// <summary>
    /// Gets the match type (X01).
    /// </summary>
    public override DartsMatchType DartsMatchType => DartsMatchType.X01;

    /// <summary>
    /// Initializes a new instance of the X01 match.
    /// </summary>
    /// <param name="requiredScore">The difficulty level (1-5), which determines the starting score.
    /// For example, 5 results in 501, 3 results in 301, etc.</param>
    /// <exception cref="ArgumentException">Thrown when the required score is outside the valid range of 1-5</exception>
    public Match(int requiredScore = 5)
    {
        if (requiredScore < 1 || requiredScore > 5)
        {
            throw new ArgumentException("Required score must be between 1 and 5");
        }

        RequiredScore = requiredScore * 100 + 1;
    }
    
    /// <summary>
    /// Starts the X01 match if there are players registered.
    /// Sets the first player as the current player and marks the match as in progress.
    /// </summary>
    public override void StartMatch()
    {
        if (!CanStartMatch()) return;
        SetCurrentPlayer(Players.First());
        MatchInProgress = true;
    }
}
