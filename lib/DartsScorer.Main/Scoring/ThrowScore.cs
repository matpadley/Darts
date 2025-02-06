namespace DartsScorer.Main.Scoring;

public class ThrowScore
{
    public readonly BoardScore BoardScore;
    public readonly Multiplier Multiplier;

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
            Multiplier.Triple => scoreValue * 3,
            _ => throw new ArgumentOutOfRangeException(nameof(multiplier), multiplier, null),
        };

        NumberScore = scoreValue;
    }

    public int NumberScore { get; private set; }

    public int Score { get; private set; }
    
    // override the ToString method to return the score and the board score
    public override string ToString()
    {
        var multiplier = Multiplier switch
        {
            Multiplier.Single => "",
            Multiplier.Double => "D",
            Multiplier.Triple => "T",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (BoardScore == BoardScore.BullsEye || BoardScore == BoardScore.OuterBull)
        {
            return BoardScore == BoardScore.BullsEye ? "Bulls Eye" : "Outer Bull" ;
        }
        
        return $"{multiplier}{(int)BoardScore}";
    }
}
