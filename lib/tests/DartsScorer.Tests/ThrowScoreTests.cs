namespace DartsScorer.Tests;

public class ThrowScoreTests
{       
    [TestCase(BoardScore.BullsEye, Multiplier.Double)]
    [TestCase(BoardScore.BullsEye, Multiplier.Triple)]
    [TestCase(BoardScore.OuterBull, Multiplier.Double)]
    [TestCase(BoardScore.OuterBull, Multiplier.Triple)]
    public void ThrowScore_Fails_With_Invalid_Multiplier_For_Special_Scores(BoardScore score, Multiplier multiplier)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ThrowScore(multiplier, score));
    }

    [TestCase(BoardScore.One, Multiplier.Single, 1)]
    [TestCase(BoardScore.Twenty, Multiplier.Single, 20)]
    [TestCase(BoardScore.Twenty, Multiplier.Double, 40)]
    [TestCase(BoardScore.Twelve, Multiplier.Triple, 36)]
    [TestCase(BoardScore.OuterBull, Multiplier.Single, 25)]
    [TestCase(BoardScore.BullsEye, Multiplier.Single, 50)]
    public void ThrowScore_Succeeds_With_Valid_Score(BoardScore score, Multiplier multiplier, int result)
    {
        var throwScore = new ThrowScore(multiplier, score);
        Assert.That(throwScore.Score, Is.EqualTo(result));
    }
}

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

    public int Score {get; private set; }
}

public enum BoardScore
{
    // add valid darts scores
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Eleven = 11,
    Twelve = 12,
    Thirteen = 13,
    Fourteen = 14,
    Fifteen = 15,
    Sixteen = 16,
    Seventeen = 17,
    Eighteen = 18,
    Nineteen = 19,
    Twenty = 20,
    OuterBull = 25,
    BullsEye = 50  
}

public enum Multiplier
{
    Single,
    Double,
    Triple
}