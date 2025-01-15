namespace DartsScorer.Tests.Player;

public class PlayerTests
{
    [Test]
    public void Player_Instantiation()
    {
        var player = new Main.Player.Player("John");
        Assert.That(player.Name, Is.EqualTo("John"));
    }

    [Test]
    public void Player_Instantiation_Fail()
    {
        var player = new Main.Player.Player("John");
        Assert.That(player.Name, !Is.EqualTo("Steven"));
    }
}