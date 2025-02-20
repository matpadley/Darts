using DartsScorer.Main.Match;
using DartsScorer.Main.Scoring;

namespace DartsScorer.Tests.Scoring;

public class LegTests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void Scoring_Instantiate()
    {
        // Arrange
        var leg = new Leg();

        // Assert
        Assert.That(leg.CurrentScore, Is.EqualTo(0));
        Assert.That(leg.NextThrow, Is.EqualTo(1));
        Assert.That(leg.IsComplete, Is.False);
    }

    [TestCase(BoardScore.Twenty, Multiplier.Single, 20)]
    [TestCase(BoardScore.BullsEye, Multiplier.Single, 50)]
    public void Scoring_Leg_Instantiation_Check_Simple_Throw(BoardScore boardScore, Multiplier multiplier, int expectedScore)
    {
        // Arrange
        var leg = new Leg();

        // Act
        leg.ThrowFirst(new ThrowScore(multiplier, boardScore));

        // Assert
        Assert.That(leg.CurrentScore, Is.EqualTo(expectedScore));
        Assert.That(leg.NextThrow, Is.EqualTo(2));
        Assert.That(leg.IsComplete, Is.False);
        Assert.That(leg.Throws.Count, Is.EqualTo(1));
        Assert.That(leg.Throws.First().Score, Is.EqualTo(expectedScore));
    }

    [Test]
    public void Scoring_Leg_Score_Array()
    {
        // Arrange
        var leg = new Leg();

        // Act
        leg.ThrowFirst(new ThrowScore(Multiplier.Single, BoardScore.Twenty));
        leg.ThrowSecond(new ThrowScore(Multiplier.Single, BoardScore.Twenty));
        Assert.That(leg.NextThrow, Is.EqualTo(3));
        Assert.That(leg.IsComplete, Is.False);
        Assert.That(leg.Throws.Count, Is.EqualTo(2));
        Assert.That(leg.Throws.First().Score, Is.EqualTo(20));
        Assert.That(leg.Throws.ElementAt(1).Score, Is.EqualTo(20));
        Assert.That(leg.CurrentScore, Is.EqualTo(40));
    }

    [Test]
    public void Scoring_Leg_Ensure_First_Throw_Cannot_Be_Thrown_Twice()
    {
        // Arrange
        var leg = new Leg();

        // Act
        leg.ThrowFirst(new ThrowScore(Multiplier.Single, BoardScore.Twenty));

        // Assert
        Assert.Throws<InvalidOperationException>(() => leg.ThrowFirst(new ThrowScore(Multiplier.Single, BoardScore.Twenty)));
    }

    [Test]
    public void Scoring_Leg_Ensure_Second_Throw_Cannot_Be_Thrown_Before_First()
    {
        // Arrange
        var leg = new Leg();

        // Assert
        Assert.Throws<InvalidOperationException>(() => leg.ThrowSecond(new ThrowScore(Multiplier.Single, BoardScore.Twenty)));
    }

    [Test]
    public void Scoring_Leg_Ensure_Third_Throw_Cannot_Be_Thrown_Before_Second()
    {
        // Arrange
        var leg = new Leg();

        // Assert
        Assert.Throws<InvalidOperationException>(() => leg.ThrowThird(new ThrowScore(Multiplier.Single, BoardScore.Twenty)));
    }
}
