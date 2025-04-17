namespace DartsScorer.Main.Scoring;

/// <summary>
/// Represents a single dart throw in a darts match.
/// Encapsulates both the board score (1-20, bull, etc.) and the multiplier (single, double, treble).
/// </summary>
public class ThrowScore
{
    /// <summary>
    /// Gets the location on the dartboard where the throw landed.
    /// </summary>
    public readonly BoardScore BoardScore;
    
    /// <summary>
    /// Gets the multiplier for this throw (Single, Double, or Treble).
    /// </summary>
    public readonly Multiplier Multiplier;

    /// <summary>
    /// Initializes a new instance of the ThrowScore class.
    /// </summary>
    /// <param name="multiplier">The multiplier of the throw (Single, Double, or Treble)</param>
    /// <param name="score">The board score where the dart landed</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to assign a multiplier to BullsEye or OuterBull</exception>
    public ThrowScore(Multiplier multiplier, BoardScore score)
    {
        BoardScore = score;
        Multiplier = multiplier;
        int scoreValue = (int)score;
        if (multiplier != Multiplier.Single && (score == BoardScore.BullsEye || score == BoardScore.OuterBull))
        {
            throw new ArgumentOutOfRangeException(nameof(score), score, "BullsEye can only be single");
        }

        Score = multiplier switch
        {
            Multiplier.Single => scoreValue,
            Multiplier.Double => scoreValue * 2,
            Multiplier.Treble => scoreValue * 3,
            _ => throw new ArgumentOutOfRangeException(nameof(multiplier), multiplier, null),
        };

        NumberScore = scoreValue;
    }

    /// <summary>
    /// Gets the raw number value from the board, without the multiplier applied.
    /// For example, a Treble 20 would have a NumberScore of 20.
    /// </summary>
    public int NumberScore { get; private set; }

    /// <summary>
    /// Gets the total score for this throw, with the multiplier applied.
    /// For example, a Treble 20 would have a Score of 60.
    /// </summary>
    public int Score { get; private set; }
    
    /// <summary>
    /// Returns a string representation of this throw in standard dart notation.
    /// For example, "T20" for treble 20, "D16" for double 16, or "Bulls Eye" for a bullseye.
    /// </summary>
    /// <returns>A string representation of the throw</returns>
    public override string ToString()
    {
        var multiplier = Multiplier switch
        {
            Multiplier.Single => "",
            Multiplier.Double => "D",
            Multiplier.Treble => "T",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (BoardScore == BoardScore.BullsEye || BoardScore == BoardScore.OuterBull)
        {
            return BoardScore == BoardScore.BullsEye ? "Bulls Eye" : "Outer Bull" ;
        }
        
        return $"{multiplier}{(int)BoardScore}";
    }
}
