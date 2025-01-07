namespace DartsScorer.Tests;

public class TestTests
{
    [Test]
    public void Instansitation()
    {
        var team = new Team("Fancy New Team");
        Assert.That(team.Name, Is.EqualTo("Fancy New Team"));
    }

    [Test]
    public void Instansitation_Fail()
    {
        var team = new Team("Fancy New Team");
        Assert.That(team.Players.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddSinglePlayer_Sucess()
    {
        var team = new Team("Fancy New Team");
        var player = new Player("John");
        team.AddNewPlayer(player);

        Assert.That(team.Players.Count, Is.EqualTo(1));
        Assert.That(team.Players[0].Name, Is.EqualTo(player.Name));
    }

    [Test]
    public void AddSinglePlayer_PlayerCount_Fail()
    {
        var team = new Team("Fancy New Team");
        var player = new Player("John");
        team.AddNewPlayer(player);

        Assert.That(team.Players.Count, !Is.EqualTo(0));
    }

    [Test]
    public void AddMultiplePlayer_Sucess()
    {
        var team = new Team("Fancy New Team");
        var player1 = new Player("John");
        var player2 = new Player("Jane");
        team.AddNewPlayer(player1);
        team.AddNewPlayer(player2);

        Assert.That(team.Count, Is.EqualTo(2));
        Assert.That(team.Players[0].Name, Is.EqualTo(player1.Name));
        Assert.That(team.Players[1].Name, Is.EqualTo(player2.Name));
    }

    [Test]
    public void AddMultiplePlayer_CannotAddDuplicates()
    {
        var team = new Team("Fancy New Team");
        var player1 = new Player("John");
        var player2 = new Player("John");
        team.AddNewPlayer(player1);
        team.AddNewPlayer(player2);

        Assert.That(team.Count, Is.EqualTo(1));
        Assert.That(team.Players[0].Name, Is.EqualTo(player1.Name));
    }
}
