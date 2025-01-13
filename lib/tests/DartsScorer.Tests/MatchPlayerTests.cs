using DartsScorer.Main.Match;

namespace DartsScorer.Tests;

public class MatchPlayerTests
{
    [Test]
    public void Match_Player_Instansitation()
    {
        var player = new Player("Fancy New Team");
        var matchPlayer = new MatchPlayer(player);
        Assert.That(matchPlayer.Name, Is.EqualTo("Fancy New Team"));
    }
}
