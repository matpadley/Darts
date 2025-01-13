using DartsScorer.Main.Models.Scores;

namespace DartsScorer.Main.Scoring;

public class ThrowScore
{
    public ThrowScore(Multiplier multiplier, BoardScore score)
    {
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
    }

    public int Score { get; private set; }
}
