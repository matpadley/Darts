using DartsScorer.Main.Match;
using Match = DartsScorer.Main.Match.x01.Match;

namespace DartsScorer.x01;

public class InstantiateTests
{
    [Test]
    public void X01_Instantiate()
    {
        var match = new Match();
        
        Assert.That(match.DartsMatchType, Is.EqualTo(DartsMatchType.X01));
        Assert.That(match.Name, Is.EqualTo("x01"));
    }
    
    [Test]
    public void X01_Instantiate_Failure()
    {
        var match = new Match();
        
        Assert.That(match.DartsMatchType, !Is.EqualTo(DartsMatchType.RoundTheBoard));
        Assert.That(match.Players.Count, Is.EqualTo(0));
    }

    [Test]
    public void X01_Default_Score()
    {
        var match = new Match();
        
        Assert.That(match.RequiredScore, Is.EqualTo(501));
    }

    [TestCase(1, 101)]
    [TestCase(2, 201)]
    [TestCase(3, 301)]
    [TestCase(4, 401)]
    [TestCase(5, 501)]
    public void X01_Custom_Score(int requiredGame, int actualGame)
    {
        var match = new Match(requiredGame);
        
        Assert.That(match.RequiredScore, Is.EqualTo(actualGame));
        Assert.That(match.IsMatchComplete, Is.False);
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(6)]
    public void X01_Custom_Score_Failure(int requiredScore)
    {
        Assert.Throws<ArgumentException>(() => new Match(requiredScore));
    }
}