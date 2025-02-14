using DartsScorer.Main.Scoring;

namespace DartsScorer.Tests.Scoring;

public class ScoringThrowTests
{
    [TestCase(BoardScore.BullsEye, Multiplier.Double)]
    [TestCase(BoardScore.BullsEye, Multiplier.Treble)]
    [TestCase(BoardScore.OuterBull, Multiplier.Double)]
    [TestCase(BoardScore.OuterBull, Multiplier.Treble)]
    public void ThrowScore_Fails_With_Invalid_Multiplier_For_Special_Scores(BoardScore score, Multiplier multiplier)
    {
        // ReSharper disable once ObjectCreationAsStatement
        Assert.Throws<ArgumentOutOfRangeException>(() => new ThrowScore(multiplier, score));
    }

    [TestCase(BoardScore.One, Multiplier.Single, 1)]
    [TestCase(BoardScore.Twenty, Multiplier.Single, 20)]
    [TestCase(BoardScore.Twenty, Multiplier.Double, 40)]
    [TestCase(BoardScore.Twelve, Multiplier.Treble, 36)]
    [TestCase(BoardScore.OuterBull, Multiplier.Single, 25)]
    [TestCase(BoardScore.BullsEye, Multiplier.Single, 50)]
    public void ThrowScore_Succeeds_With_Valid_Score(BoardScore score, Multiplier multiplier, int result)
    {
        var throwScore = new ThrowScore(multiplier, score);
        Assert.That(throwScore.Score, Is.EqualTo(result));
    }
}
