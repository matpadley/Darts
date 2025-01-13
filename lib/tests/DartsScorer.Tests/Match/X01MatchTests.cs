using DartsScorer.Main.Match.x01;

namespace DartsScorer.Tests;

public class X01MatchTests
{
    [Test]
    public void Match_Instantiate_X01_Match_Success()
    {
        var match = new Match();

        Assert.That(match.MatchType, Is.EqualTo(Main.Match.MatchType.x01));
        Assert.That(match.Players.Count, Is.EqualTo(0));
    }

    [Test]
    public void Match_Instantiate_Match_X01_Fail()
    {
        var match = new Match();

        Assert.That(match.MatchType, Is.Not.EqualTo(Main.Match.MatchType.Killer));
    }

    [Test]
    public void Match_Instantiate_Match_501_Sucess()
    {
        var match = new Match();

        Assert.That(match.RequiredScore, Is.EqualTo(501));
    }

    [Test]
    public void Match_Instantiate_Match_Custom_Score_Sucess()
    {
        var match = new Match(1);

        Assert.That(match.RequiredScore, Is.EqualTo(101));
    }

    [Test]
    public void Match_Instantiate_Match_Custom_Score_Must_Be_Between_One_and_Five()
    {
        Assert.Throws<ArgumentException>(() => new Match(12));
    }

    [Test]
    public void Match_Can_Add_Player()
    {
        var match = new Match();
        var player = new Player("Player 1");
        match.AddPlayer(player);

        Assert.That(match.Players.Count, Is.EqualTo(1));
    }
}