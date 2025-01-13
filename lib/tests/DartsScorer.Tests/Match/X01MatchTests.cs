using DartsScorer.Main.Match;
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
        Assert.That(match.Sets.Count, Is.EqualTo(0));
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

    [Test]
    public void Match_Throws_Exception_If_Match_Started_With_No_Players()
    {
        var match = new Match();

        Assert.Throws<InvalidOperationException>(() => match.StartMatch());
    }

    [Test]
    public void Match_Start_Match_With_Correct_Player()
    {
        var match = new Match();
        var player1 = new Player("Player 1");
        var player2 = new Player("Player 2");
        match.AddPlayer(player1);
        match.AddPlayer(player2);

        match.StartMatch();
        
        Assert.That(match.CurrentPlayer?.Name, Is.EqualTo("Player 1"));
    }

    [Test]
    public void Match_Start_Match_With_First_Set()
    {
        var match = new Match();
        var player1 = new Player("Player 1");
        var player2 = new Player("Player 2");
        match.AddPlayer(player1);
        match.AddPlayer(player2);

        match.StartMatch();
        
        Assert.That(match.Sets, Is.Not.Null);
    }
}