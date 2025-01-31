namespace DartsScorer.Tests.Match;

public class MatchPlayerTests
{
    [Test]
    public void Match_Player_Instantiation()
    {
        var player = new Main.Player.Player("Fancy New Team");
        Assert.That(player.Name, Is.EqualTo("Fancy New Team"));
    }
}
