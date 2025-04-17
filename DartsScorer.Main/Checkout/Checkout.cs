using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Checkout;

/// <summary>
/// Calculates optimal checkout patterns for X01 games.
/// This class uses pre-computed checkout patterns to suggest the best sequence of throws
/// to finish a game from a given remaining score.
/// </summary>
public class CheckoutCalculator
{
    /// <summary>
    /// A dictionary of pre-computed optimal checkout patterns for scores from 2-170.
    /// </summary>
    private readonly Dictionary<int, ThrowScore[]> _checkouts = CheckoutData.Scores;

    /// <summary>
    /// Calculates the optimal checkout pattern for a given remaining score.
    /// </summary>
    /// <param name="number">The remaining score to checkout</param>
    /// <returns>An array of ThrowScore objects representing the optimal checkout sequence,
    /// or an empty array if no checkout is possible</returns>
    public ThrowScore[] Calculate(int number)
    {
        var checkoutNeeded = _checkouts.FirstOrDefault(cd => cd.Key == number);

        if (checkoutNeeded.Value != null)
        {
            return checkoutNeeded.Value;
        }

        return [];
    }
}