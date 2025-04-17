using DartsScorer.Main.Checkout;
using DartsScorer.Main.Player;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match.x01;

/// <summary>
/// Represents a player in an X01 darts match.
/// X01 players start with a specified score and aim to reduce it to exactly zero.
/// </summary>
/// <param name="name">The name of the player</param>
/// <param name="winningNumber">The starting score for this player (301, 501, etc.)</param>
public class X01Player(string name, int winningNumber) : MatchPlayer(new Player.Player(name))
{
    private CheckoutCalculator _checkoutCalculator = new CheckoutCalculator();
    
    /// <summary>
    /// Gets or sets the starting score for this player.
    /// </summary>
    public int WinningNumber { get; set; } = winningNumber;

    /// <summary>
    /// Gets the player's current remaining score.
    /// </summary>
    public int RemainingScore { get; private set; } = winningNumber;
    
    /// <summary>
    /// Calculates the current score as the difference between the starting score and remaining score.
    /// </summary>
    /// <returns>The current score</returns>
    public int CurrentScore() => WinningNumber - RemainingScore;
    
    /// <summary>
    /// Updates the player's remaining score based on the latest throw.
    /// If the throw would reduce the score below zero, the throw is ignored (bust).
    /// </summary>
    /// <param name="newThrow">The latest throw made by the player</param>
    public override void UpdateRequiredBoardNumber(ThrowScore newThrow)
    {
        if (RemainingScore >= newThrow.Score)
        {
            RemainingScore -= newThrow.Score;
        }
        
        HasWon = RemainingScore == 0;
    }

    /// <summary>
    /// Determines whether this player has finished the match by reducing their score to exactly zero.
    /// </summary>
    /// <returns>true if the player has reduced their score to zero; otherwise, false</returns>
    public override bool Finished() => HasWon;

    /// <summary>
    /// Calculates the optimal checkout path for the player's current remaining score.
    /// </summary>
    /// <returns>An array of throws representing the optimal checkout sequence</returns>
    public ThrowScore[] Checkout() => _checkoutCalculator.Calculate(RemainingScore);
}