using System;

namespace DartsScorer.Tests;

public class LegTests
{
    [SetUp]
    public void Setup()
    {}

    [Test]
    public void InstatiateLeg()
    {
        // Arrange
        var leg = new Leg();

        // Act
        leg.AddFirstDart(new ThrowScore(Multiplier.Single, BoardScore.Twenty));

        // Assert
        Assert.That(leg.CurrentScore, Is.EqualTo(20));
    }
}

public class Leg
{
    public int CurrentScore { get; private set; }

    public void AddFirstDart(ThrowScore throwScore)
    {
        CurrentScore += throwScore.Score;
    }

    public void AddSecondDart(ThrowScore throwScore)
    {
        CurrentScore += throwScore.Score;
    }

    public void AddThirdDart(ThrowScore throwScore)
    {
        CurrentScore += throwScore.Score;
    }
}
