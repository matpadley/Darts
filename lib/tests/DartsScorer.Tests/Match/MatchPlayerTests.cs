using MatchPlayer = DartsScorer.Main.Match.MatchPlayer;

namespace DartsScorer.Tests.Match;

public class MatchPlayerTests
{
    [Test]
    public void Match_Player_Instantiation()
    {
        var player = new Main.Player.Player("Fancy New Team");
        var matchPlayer = new MatchPlayer(player);
        Assert.That(matchPlayer.Name, Is.EqualTo("Fancy New Team"));
    }
}
