using DartsScorer.Main.Match;
using DartsScorer.Main.Match.x01;

namespace DartsScorer.x01;

public class MatchX01Tests
{
    [Test]
    public void Match_X01_Instantiation()
    {
        var match = new Match();

        Assert.That(match.DartsMatchType, Is.EqualTo(DartsMatchType.X01));
        Assert.That(match.Players.Count, Is.EqualTo(0));
        Assert.That(match.Sets.Count, Is.EqualTo(0));
        Assert.That(match.Name, Is.EqualTo("x01"));
    }

    [Test]
    public void Match_X01_Instantiation_Fail()
    {
        var match = new Match();

        Assert.That(match.DartsMatchType, Is.Not.EqualTo(DartsMatchType.Killer));
    }

    [Test]
    public void Match_X01_Instantiation_501_Success()
    {
        var match = new Match();

        Assert.That(match.RequiredScore, Is.EqualTo(501));
    }

    [Test]
    public void Match_X01_Instantiation_Custom_Score_Success()
    {
        var match = new Match(1);

        Assert.That(match.RequiredScore, Is.EqualTo(101));
    }

    [Test]
    public void Match_X01_Instantiation_Custom_Score_Must_Be_Between_One_and_Five()
    {
        Assert.Throws<ArgumentException>(() => new Match(12));
    }

    [Test]
    public void Match_X01_Instantiation_Can_Add_Player()
    {
        var match = new Match();
        var player = new Main.Player.Player("Player 1");
        match.AddPlayer(player);

        Assert.That(match.Players.Count, Is.EqualTo(1));
    }

    [Test]
    public void Match_X01_Instantiation_Throws_Exception_If_Match_Started_With_No_Players()
    {
        var match = new Match();

        Assert.Throws<InvalidOperationException>(() => match.StartMatch());
    }

    [Test]
    public void Match_X01_Instantiation_Start_Match_With_Correct_Player()
    {
        var match = new Match();
        var player1 = new Main.Player.Player("Player 1");
        var player2 = new Main.Player.Player("Player 2");
        match.AddPlayer(player1);
        match.AddPlayer(player2);

        match.StartMatch();

        Assert.That(match.CurrentPlayer?.Name, Is.EqualTo("Player 1"));
    }

    [Test]
    public void Match_X01_Instantiation_Start_Match_With_First_Set()
    {
        var match = new Match();
        var player1 = new Main.Player.Player("Player 1");
        var player2 = new Main.Player.Player("Player 2");
        match.AddPlayer(player1);
        match.AddPlayer(player2);

        match.StartMatch();

        Assert.That(match.Sets, Is.Not.Null);
    }
}