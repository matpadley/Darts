namespace DartsScorer.Main.Scoring;

/// <summary>
/// Represents the multiplier applied to a dart throw based on which section of the dartboard was hit.
/// </summary>
public enum Multiplier
{
    /// <summary>
    /// A single, which multiplies the score by 1 (no change).
    /// This represents hitting the main colored sections of the dartboard.
    /// </summary>
    Single,
    
    /// <summary>
    /// A double, which multiplies the score by 2.
    /// This represents hitting the outer narrow ring of the dartboard.
    /// </summary>
    Double,
    
    /// <summary>
    /// A treble (or triple), which multiplies the score by 3.
    /// This represents hitting the inner narrow ring of the dartboard.
    /// </summary>
    Treble
}