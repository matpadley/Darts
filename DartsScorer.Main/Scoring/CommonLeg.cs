namespace DartsScorer.Main.Scoring;

/// <summary>
/// Abstract base class for dart legs.
/// Defines the common structure and behavior for all types of dart legs.
/// </summary>
public abstract class CommonLeg
{
    /// <summary>
    /// Gets or sets the current accumulated score for this leg.
    /// </summary>
    public int CurrentScore { get; internal set; }
    
    /// <summary>
    /// Gets or sets the index of the next throw (1, 2, or 3).
    /// </summary>
    public int NextThrow { get; internal set; } = 1;
    
    /// <summary>
    /// Gets or sets a value indicating whether this leg is complete.
    /// </summary>
    public bool IsComplete { get; internal set; }
    
    /// <summary>
    /// Gets the collection of throws made in this leg.
    /// </summary>
    public ICollection<ThrowScore> Throws { get; } = new List<ThrowScore>();
    
    /// <summary>
    /// Records the first throw in this leg.
    /// </summary>
    /// <param name="throwScore">The score of the first throw</param>
    public abstract void ThrowFirst(ThrowScore throwScore);
    
    /// <summary>
    /// Records the second throw in this leg.
    /// </summary>
    /// <param name="throwScore">The score of the second throw</param>
    public abstract void ThrowSecond(ThrowScore throwScore);
    
    /// <summary>
    /// Records the third throw in this leg.
    /// </summary>
    /// <param name="throwScore">The score of the third throw</param>
    public abstract void ThrowThird(ThrowScore throwScore);
}
