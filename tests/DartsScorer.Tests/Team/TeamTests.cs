using System.Linq;

namespace DartsScorer.Tests.Team;

public class TeamTests
{
    [Test]
    public void Team_Instantiation()
    {
        var team = new Main.Player.Team("Fancy New Team");
        Assert.That(team.Name, Is.EqualTo("Fancy New Team"));
    }

    [Test]
    public void Team_Instantiation_Fail()
    {
        var team = new Main.Player.Team("Fancy New Team");
        Assert.That(team.Players.Count, Is.EqualTo(0));
    }

    [Test]
    public void Team_Add_Single_Player_Success()
    {
        var team = new Main.Player.Team("Fancy New Team");
        var player = new Main.Player.Player("John");
        team.AddNewPlayer(player);

        Assert.That(team.Players.Count, Is.EqualTo(1));
        Assert.That(team.Players.First().Name, Is.EqualTo(player.Name));
    }

    [Test]
    public void Team_Add_Single_Player_Player_Count_Fail()
    {
        var team = new Main.Player.Team("Fancy New Team");
        var player = new Main.Player.Player("John");
        team.AddNewPlayer(player);

        Assert.That(team.Players.Count, !Is.EqualTo(0));
    }

    [Test]
    public void Team_Add_Multiple_Player_Success()
    {
        var team = new Main.Player.Team("Fancy New Team");
        var player1 = new Main.Player.Player("John");
        var player2 = new Main.Player.Player("Jane");
        team.AddNewPlayer(player1);
        team.AddNewPlayer(player2);

        Assert.That(team.Count, Is.EqualTo(2));
        var players = team.Players.ToList();
        Assert.That(players[0].Name, Is.EqualTo(player1.Name));
        Assert.That(players[1].Name, Is.EqualTo(player2.Name));
    }

    [Test]
    public void Team_Add_Multiple_Player_CannotAddDuplicates()
    {
        var team = new Main.Player.Team("Fancy New Team");
        var player1 = new Main.Player.Player("John");
        var player2 = new Main.Player.Player("John");
        team.AddNewPlayer(player1);
        team.AddNewPlayer(player2);

        Assert.That(team.Count, Is.EqualTo(1));
        Assert.That(team.Players.First().Name, Is.EqualTo(player1.Name));
    }
}
