using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Match;

/// <summary>
/// Represents a leg in a darts match, tracking a sequence of three throws.
/// A leg is a basic unit of play in darts, consisting of three dart throws.
/// </summary>
public class Leg : CommonLeg
{
    /// <summary>
    /// Initializes a new instance of the Leg class.
    /// Sets the next throw to 1 and records the creation time.
    /// </summary>
    public Leg()
    {
        NextThrow = 1;
        CreationDate = DateTime.Now;
    }

    /// <summary>
    /// Gets or sets the date and time when this leg was created.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Records the first throw in this leg.
    /// </summary>
    /// <param name="throwScore">The score of the first throw</param>
    /// <exception cref="InvalidOperationException">Thrown when attempting to record the first throw after it has already been thrown</exception>
    public override void ThrowFirst(ThrowScore throwScore)
    {
        // Using pattern matching with discard pattern
        if (NextThrow is not 1)
        {
            throw new InvalidOperationException("First throw already thrown");
        }

        CurrentScore += throwScore.Score;
        NextThrow = 2;
        Throws.Add(throwScore);
    }

    /// <summary>
    /// Records the second throw in this leg.
    /// </summary>
    /// <param name="throwScore">The score of the second throw</param>
    /// <exception cref="InvalidOperationException">Thrown when attempting to record the second throw out of sequence</exception>
    public override void ThrowSecond(ThrowScore throwScore)
    {
        // Using pattern matching with discard pattern
        if (NextThrow is not 2)
        {
            throw new InvalidOperationException("Second can only be thrown on the next throw of 2");
        }

        CurrentScore += throwScore.Score;
        NextThrow = 3;
        Throws.Add(throwScore);
    }

    /// <summary>
    /// Records the third throw in this leg.
    /// Completes the leg after the third throw is recorded.
    /// </summary>
    /// <param name="throwScore">The score of the third throw</param>
    /// <exception cref="InvalidOperationException">Thrown when attempting to record the third throw out of sequence</exception>
    public override void ThrowThird(ThrowScore throwScore)
    {
        // Using pattern matching with discard pattern
        if (NextThrow is not 3)
        {
            throw new InvalidOperationException("Third can only be thrown on the next throw of 3");
        }

        CurrentScore += throwScore.Score;
        Throws.Add(throwScore);
        NextThrow = 1;
        IsComplete = true;
    }
}
