namespace DartsScorer.Main.Scoring;

public class ThrowScore
{
    public BoardScore BoardScore;
    public Multiplier Multiplier { get; }

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
}
